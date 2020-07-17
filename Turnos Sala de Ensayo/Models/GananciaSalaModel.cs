using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Models
{
    public class GananciaSalaModel
    {

        public int IdSala { get; set; }

        public String NombreSala { get; set; }

        public int CantidadReservasSala { get; set; }

        public double GananciasSala { get; set; }

        public String MesSala { get; set; }
    }
}