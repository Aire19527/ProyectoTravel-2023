using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Travel.Domain.DTO.Library
{
    public class Autor_DTO
    {
        [MaxLength(200)]
        [Required(ErrorMessage = "El campo [Nombre] es obligatoro")]
        public string Name { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "El campo [Apellido] es obligatoro")]
        public string LastName { get; set; }

    }
}
