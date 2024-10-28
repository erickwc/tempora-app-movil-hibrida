using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempora.MAUIApp.Models
{
    public class Dia
    {
        [Key, Required]
        public long DiaId { get; set; }

        [Required]
        public int PeriodoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public TimeSpan? HoraInicioManana { get; set; }

        public TimeSpan? HoraFinManana { get; set; }

        public TimeSpan? HoraInicioTarde { get; set; }

        public TimeSpan? HoraFinTarde { get; set; }

        public string HorasTotales { get; set; } = string.Empty;

        //Relacion
        public Periodo? Periodo { get; set; }
    }
}
