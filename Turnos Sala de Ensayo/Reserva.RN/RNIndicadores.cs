using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Datos;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class RNIndicadores
    {
        public static int[] DevolverCantTurnosOcupados(int idSala, DateTime fechaInicio, DateTime fechaFin)
        {
            int[] TurnosOcupadosPorFecha = new int[30];

            List<Models.TurnosModel> ListaDeTurnos = ADTurnos.DevolverTurnosOcupados(idSala, fechaInicio, fechaFin);
            
            foreach(Models.TurnosModel Turno in ListaDeTurnos)
            {
                int i = DateFormat.NumeroFecha(Convert.ToDateTime(Turno.fecha));

                TurnosOcupadosPorFecha[i-1]++;
            }

            return TurnosOcupadosPorFecha;
        }

    }
}