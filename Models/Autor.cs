using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Autor
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorName { get; set; }
        public List<Livro> Livro { get; set; }
    }
}
