using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Travel.Domain.DTO.Library.Book
{
    public class AddBook_Dto
    {
        public int IdEditorial { get; set; }
        public int IdAutor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Sinopsis { get; set; }
        public int N_Pages { get; set; }

        public IFormFile FileImage { get; set; }
    }
}
