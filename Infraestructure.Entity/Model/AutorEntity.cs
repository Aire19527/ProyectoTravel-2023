using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Infraestructure.Entity.Model
{
    [Table("Autor", Schema = "Library")]
    public class AutorEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }


        [NotMapped]
        public string FullName { get { return $"{this.Name} {this.LastName}"; } }


        public IEnumerable<BookEntity> BookEntities { get; set; }
    }
}
