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
        public int IdUsuario { get; set; }

        public int IdTurno { get; set; }


        public ReservaDeSala(int idSala, int idUsuario, int idTurno)
        {
            this.IdSala = idSala;
            this.IdUsuario = idUsuario;
            this.IdTurno = idTurno;
        }

        public ReservaDeSala() {
        }
        
    }
}