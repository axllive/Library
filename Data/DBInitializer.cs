using Library.Models;
using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Library.Data
{
    public class DBInitializer
    {
        public static void Initialize(LibraryContext context)
        {

            //if (context.Alunos.Count() > 2) return;

            //var alunos = new List<UsuarioModel>();

            //alunos.Add(new UsuarioModel { Usuario = "axllive", Senha = "12345$@", Aluno = "Alex Andrade", IsAdmin = true, Livros = null });
            //alunos.Add(new UsuarioModel { Usuario = "Alonso", Senha = "12345$", Aluno = "Alonso", IsAdmin = false, Livros = null });
            //alunos.Add(new UsuarioModel { Usuario = "Anand", Senha = "12345$", Aluno = "Anand", IsAdmin = false, Livros = null });
            //alunos.Add(new UsuarioModel { Usuario = "Barzdukas", Senha = "12345$", Aluno = "Barzdukas", IsAdmin = false, Livros = null });
            //alunos.Add(new UsuarioModel { Usuario = "Li", Senha = "12345$", Aluno = "Li", IsAdmin = false, Livros = null });
            //alunos.Add(new UsuarioModel { Usuario = "Justice", Senha = "12345$", Aluno = "Justice", IsAdmin = false, Livros = null });
            //alunos.Add(new UsuarioModel { Usuario = "Norman", Senha = "12345$", Aluno = "Norman", IsAdmin = false, Livros = null });
            //alunos.Add(new UsuarioModel { Usuario = "Olivetto", Senha = "12345$", Aluno = "Olivetto", IsAdmin = false, Livros = null });


            //var autor = new List<Autor>
            //{
            //new Autor{AuthorID=1050,AuthorName="Bluebell Thorpe" },
            //new Autor{AuthorID=4022,AuthorName="Maureen Pierce"},
            //new Autor{AuthorID=4041,AuthorName="Mabel Parkes"},
            //new Autor{AuthorID=1045,AuthorName="Federico Blackburn"},
            //new Autor{AuthorID=3141,AuthorName="Abu Andersen"},
            //new Autor{AuthorID=2021,AuthorName="Neel Macfarlane"},
            //new Autor{AuthorID=2042,AuthorName="Safiyah Dowling"}
            //};
            //foreach (Autor c in autor)
            //{
            //    context.Autores.Add(c);
            //}
            //context.SaveChanges();

            //foreach (UsuarioModel s in alunos)
            //{
            //    context.Alunos.Add(s);
            //}
            //context.SaveChanges();

            //var livros = new List<Livro>
            //{
            //new Livro{Nome="Chemistry",IsBorrowed=false, Autor = autor.Find( x => x.AuthorID.Equals(1050)), AutorID = 1050 },
            //new Livro{Nome="Microeconomics",IsBorrowed=false, Autor = autor.Find( x => x.AuthorID.Equals(4022)), AutorID = 4022},
            //new Livro{Nome="Macroeconomics",IsBorrowed=false, Autor = autor.Find( x => x.AuthorID.Equals(4041)), AutorID = 4041},
            //new Livro{Nome="Calculus",IsBorrowed=false, Autor = autor.Find( x => x.AuthorID.Equals(1045)), AutorID = 1045},
            //new Livro{Nome="Trigonometry",IsBorrowed=false, Autor = autor.Find( x => x.AuthorID.Equals(3141)), AutorID = 3141},
            //new Livro{Nome="Composition",IsBorrowed=false, Autor = autor.Find( x => x.AuthorID.Equals(2021)), AutorID = 2021},
            //new Livro{Nome="Literature",IsBorrowed=false, Autor = autor.Find( x => x.AuthorID.Equals(2042)), AutorID = 2042},
            //};
            //foreach (Livro e in livros)
            //{
            //    context.Livros.Add(e);
            //}
            //context.SaveChanges();



            }
        }

}
