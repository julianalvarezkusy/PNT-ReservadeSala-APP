using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Turnos_Sala_de_Ensayo.Models
{
    public class TurnosModel
    {
        public int Id { get; set; }
        public String fecha { get; set; }

        //public DateTime fechaDatetime { get; set; }

        public String hora { get; set; }

        //public decimal horaDecimal { get; set; }

    }
}