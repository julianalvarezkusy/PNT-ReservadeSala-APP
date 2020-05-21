using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Reserva.Entidades
{
    public class ReservaDeSala
    {
        public int Id { get; set; }
        public int IdSala { get; set; }
        public Usuario Usuario { get; set; }

        public Turno Turno { get; set; }
    }
}