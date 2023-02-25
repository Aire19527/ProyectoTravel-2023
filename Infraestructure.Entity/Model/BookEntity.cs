using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Model
{
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EditorialEntity")]
        public int IdEditorial { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Sinopsis { get; set; }
        public int N_Pages { get; set; }


        public EditorialEntity EditorialEntity { get; set; }

        public IEnumerable<AutorBookEntity> AutorBookEntities { get; set; }
    }
}
