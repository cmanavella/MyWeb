using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de E-Mail incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100.")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}