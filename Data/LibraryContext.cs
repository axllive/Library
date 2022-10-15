using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    

   
        public class LibraryContext : DbContext
        {
            public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
            { 
            }
        
                public DbSet<Autor> Autores { get; set; }
                public DbSet<Livro> Livros { get; set; }
                public DbSet<UsuarioModel> Alunos { get; set; }

        
        }
    }
