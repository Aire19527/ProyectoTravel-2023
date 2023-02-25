using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Infraestructure.Entity.Model
{
    public class AutoresEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }

        public IEnumerable<AutorBookEntity> AutorBookEntities { get; set; }
    }
}
