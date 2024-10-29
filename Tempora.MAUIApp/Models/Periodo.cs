using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempora.MAUIApp.Models
{
    public class Periodo
    {
        [Key, Required]
        public int PeriodoId { get; set; }

        [Required]
        public int EstadoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int CantidadHoras { get; set; }

        [Required, MaxLength(50)]
        public string HorasRealizadas { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string HorasPendientes { get; set; } = string.Empty;

        [Required]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public TimeSpan HoraRegistro { get; set; }

        //Relacion
        public Estado? Estado { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
