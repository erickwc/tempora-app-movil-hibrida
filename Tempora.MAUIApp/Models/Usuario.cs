using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tempora.MAUIApp.Models
{
    public class Credenciales
    {
        [Required, StringLength(8)]
        public string Telefono { get; set; } = string.Empty;

        [Required, StringLength(250)]
        public string Clave { get; set; } = string.Empty;
    }

    public class Usuario
    {
        [Key, Required]
        public int UsuarioId { get; set; }

        [Required, MaxLength(20)]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(8)]
        public string Telefono { get; set; } = string.Empty;

        [Required, MaxLength(250)]
        public string Clave { get; set; } = string.Empty;
    }
}
