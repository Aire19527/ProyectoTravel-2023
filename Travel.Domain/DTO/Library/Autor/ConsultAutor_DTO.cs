using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Travel.Domain.DTO.Library.Autor
{
    public class ConsultAutor_DTO : Autor_DTO
    {
        [Required(ErrorMessage = "El campo [Id] es obligatoro")]
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
