using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Reserva.Entidades
{
    public class ReservaAdicional
    {
        public int id { get; set; }

        public int idReserva { get; set; }

        public int idAdicional { get; set; }
    }
}