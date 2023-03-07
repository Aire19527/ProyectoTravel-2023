using System.ComponentModel.DataAnnotations;

namespace Travel.Domain.DTO.Library.Editorial
{
    public class AddEditorial_Dto
    {
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [MaxLength(200)]
        [Required]
        public string Sede { get; set; }
    }
}
