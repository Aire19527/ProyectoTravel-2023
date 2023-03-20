using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Travel.Domain.DTO.User
{
    public class AddUserDto : LoginDto
    {
        [Required(ErrorMessage = "El Nombre es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string FullName { get { return $"{this.Name} {this.LastName}"; } }
    }
}
