using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Library.Models
{
    public class Livro
    {
        [Key]
        public int LivroID { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        public bool IsBorrowed { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InicioEmprestimo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FimEmprestimo { get; set; }

        
        [ForeignKey("UsuarioModel")]
        [DisplayFormat(NullDisplayText = "Não está emprestado")]
        public int UsrID { get; set; }
        public UsuarioModel Aluno { get; set; }


        [ForeignKey("Autor")]
        public int AutorID { get; set; }
        public Autor Autor { get; set; }
    }
}
