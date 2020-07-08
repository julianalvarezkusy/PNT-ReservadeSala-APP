using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Datos;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class RNSalas
    {
        public static List<Models.SalaModel> devolverSala()
        {
            return ADSalas.devolverSala();
        }

        public static void crearSala(Sala sala)
        {

            ADSalas.crearSala(sala);
        }
    }
}