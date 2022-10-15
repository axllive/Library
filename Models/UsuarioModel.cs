using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsrID { get; set; }
        [Required]
        [StringLength(10)]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [StringLength(50)]
        public string Aluno { get; set; }
        public bool IsAdmin { get; set; }
        [DisplayFormat(NullDisplayText = "Não possui livros emprestados")]
        public ICollection<Livro> Livros { get; set; }

    }
}
