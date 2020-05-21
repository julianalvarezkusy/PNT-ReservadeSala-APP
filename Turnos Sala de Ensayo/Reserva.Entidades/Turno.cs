using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Reserva.Entidades
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Hora { get; set; }

    }
}