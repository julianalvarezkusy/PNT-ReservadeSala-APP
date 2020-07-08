using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Models
{
    public class ReservaDatosModel
    {
        public int Id { get; set; }
         public String Fecha { get; set; }
        public String Hora { get; set; }

        public String Usuario { get; set; }

        public int IdSala { get; internal set; }
    }
}