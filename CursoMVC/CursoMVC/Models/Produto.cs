using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Produto
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(50, ErrorMessage ="O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength =2)]
        [Required(ErrorMessage ="O campo {0} é obrigatório!")]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Range(1, 10, ErrorMessage ="O campo {0} deve ser preenchido entre os valores {1} e {2}")]
        public int Quantidade { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
