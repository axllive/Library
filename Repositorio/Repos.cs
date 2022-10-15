using Library.Models;
using System.Collections.Generic;

namespace Library.Repositorio
{
    public class Repos : IRepos
    {
        #region Usuario
        public UsuarioModel AdicionarUsr(UsuarioModel contato)
        {
            throw new System.NotImplementedException();
        }

        public List<UsuarioModel> Consultar()
        {
            throw new System.NotImplementedException();
        }

        public UsuarioModel ConsultarUmUsr(int id)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioModel EditarUsr(UsuarioModel contato)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioModel ExcluirUsr(UsuarioModel contato)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Autor
        public Autor AdicionarAutor(Autor contato)
        {
            throw new System.NotImplementedException();
        }
        public Autor ConsultarUmAutor(string nome)
        {
            throw new System.NotImplementedException();
        }
        public Autor EditarAutor(Autor contato)
        {
            throw new System.NotImplementedException();
        }
        public Autor ExcluirAutor(Autor contato)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Livro
        public Livro AdicionarLivro(Livro contato)
        {
            throw new System.NotImplementedException();
        }
        public Livro ConsultarUmLivro(string nome)
        {
            throw new System.NotImplementedException();
        }
        public Livro EditarLivro(Livro contato)
        {
            throw new System.NotImplementedException();
        }
        public Livro ExcluirLivro(Livro contato)
        {
            throw new System.NotImplementedException();
        }
        #endregion


    }
}
