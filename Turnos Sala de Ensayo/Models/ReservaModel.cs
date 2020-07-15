using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Models
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdTurno { get; set; }
        public int IdSala { get; set; }
        public List<ServicioAdicionalModel> ServiciosAdicionales { get; set;  }
    }
}