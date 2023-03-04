using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model
{
    [Table("Editorial", Schema = "Library")]
    public class EditorialEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]

        public string Sede { get; set; }

        public IEnumerable<BookEntity> BookEntities { get; set; }
    }
}
