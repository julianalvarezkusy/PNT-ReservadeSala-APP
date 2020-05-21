using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Datos;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class GestorDeReserva
    {
        public bool PuedoReservar(int idSala, 
            DateTime fecha, decimal hora)
        {
            var turno = ADTurnos.Buscar(fecha, hora);
            var reserva = ADReservasDeSalas.Buscar(idSala, turno);
            if (reserva == null)
                return false;
            return true;
        }

        public void ConstruirTurnos(DateTime fechaDesde, DateTime fechaHasta)
        {
            DateTime fecha = fechaDesde;
            do
            {
                for (int i = 16; i <= 23; i++)
                {
                    ADTurnos.Agregar(
                        new Entidades.Turno()
                        {
                            Fecha = fecha,
                            Hora = i
                        }
                        );
                    ADTurnos.Agregar(
                        new Entidades.Turno()
                        {
                            Fecha = fecha,
                            Hora = i + 0.5M
                        }
                        );
                }
                fecha = fecha.AddDays(1);
            } while (fecha != fechaHasta);
        }
    }
}