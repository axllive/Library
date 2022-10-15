using System.Collections.Generic;
using System;
using Library.Models;

namespace Library.Repositorio
{
    public interface IRepos
    {
        List<UsuarioModel> Consultar();
        UsuarioModel ConsultarUmUsr(int id);
        UsuarioModel AdicionarUsr(UsuarioModel contato);
        UsuarioModel EditarUsr(UsuarioModel contato);
        UsuarioModel ExcluirUsr(UsuarioModel contato);
        Autor ConsultarUmAutor(string nome);
        Autor AdicionarAutor(Autor contato);
        Autor EditarAutor(Autor contato);
        Autor ExcluirAutor(Autor contato);
        Livro ConsultarUmLivro(string nome);
        Livro AdicionarLivro(Livro contato);
        Livro EditarLivro(Livro contato);
        Livro ExcluirLivro(Livro contato);
    }
}
