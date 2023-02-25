using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.Entity.Model
{
    public class EditorialEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Sede { get; set; }

        public IEnumerable<BookEntity> BookEntities { get; set; }
    }
}
