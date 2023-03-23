using System.ComponentModel.DataAnnotations;

namespace Travel.Domain.DTO.User
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [MaxLength(20, ErrorMessage = "El Usuario es de máximo {1} carácteres")]
        [MinLength(4, ErrorMessage = "El Usuario es de mínimo {1} carácteres")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
