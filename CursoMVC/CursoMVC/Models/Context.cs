using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-CV9KCCO0\\SQLEXPRESS;Database=BootcampLocalizaMrvCursoMvc;Trusted_Connection=True;MultipleActiveResultSets=true");
            
        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
