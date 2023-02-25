using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.Entity.Model
{
    public class AutorBookEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AutoresEntity")]
        public int IdAutor { get; set; }

        [ForeignKey("BookEntity")]
        public int IdBook { get; set; }

        public BookEntity BookEntity { get; set; }
        public AutoresEntity AutoresEntity { get; set; }
    }
}
