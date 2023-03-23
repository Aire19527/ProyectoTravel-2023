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
        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido.")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "La confirmación de la contraseña es requerida.")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string FullName { get { return $"{this.Name} {this.LastName}"; } }
    }
}
