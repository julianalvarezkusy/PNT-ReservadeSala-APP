using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Models
{
    public class SemanaModel
    {
        public int IdSala { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Models.TurnosModel[,] MatrizDeTurnos { get; set; }
    }
}