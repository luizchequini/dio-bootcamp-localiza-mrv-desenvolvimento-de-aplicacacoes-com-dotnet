using CursoAPI.Controllers;
using CursoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CursoTest
{
    public class ProdutoControllerTest
    {
        private readonly Mock<DbSet<Produto>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Produto _produto;
        private readonly Categoria _categoria;
        public ProdutoControllerTest()
        {
            _mockSet = new Mock<DbSet<Produto>>();
            _mockContext = new Mock<Context>();
            _produto = new Produto { Id = 1, Descricao = "Teste produto", Quantidade = 5, CategoriaId = 1 };

            _mockContext.Setup(m => m.Produtos).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Produtos.FindAsync(1)).ReturnsAsync(_produto);

            _mockContext.Setup(m => m.SetModified(_produto));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        }

        [Fact]
        public async Task Get_Produto()
        {
            var service = new ProdutosController(_mockContext.Object);

            await service.GetProduto(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
        }

        [Fact]
        public async Task Put_Produto()
        {
            var service = new ProdutosController(_mockContext.Object);

            await service.PutProduto(1, _produto);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Post_Produto()
        {
            var service = new ProdutosController(_mockContext.Object);

            await service.PostProduto(_produto);

            _mockSet.Verify(m => m.Add(_produto), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task Delete_Produto()
        {
            var service = new ProdutosController(_mockContext.Object);

            await service.DeleteProduto(1);

            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
            _mockSet.Verify(m => m.Remove(_produto), Times.Once());

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
