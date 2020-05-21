using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class GestorDeReserva
    {
        public Boolean PuedoReservar(int IdSala, String Fecha, String Hora)
        {
            int IdTurno;
            Boolean PuedoReservar = false;

            IdTurno = buscarTurno(Fecha, Hora);

            if(validarReserva(IdSala, Turno))
            {
                PuedoReservar = true;
            }

            return PuedoReservar;
        }

        public void ConstruirTurnos()
        {

        }
    }
}