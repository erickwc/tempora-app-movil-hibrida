using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempora.MAUIApp.Models
{
    public class Estado
    {
        [Key, Required]
        public byte EstadoId { get; set; }

        [Required, StringLength(15)]
        public string Nombre { get; set; } = string.Empty;
    }
}
