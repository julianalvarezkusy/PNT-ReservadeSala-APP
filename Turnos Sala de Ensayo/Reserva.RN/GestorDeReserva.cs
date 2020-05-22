using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public static void ConstruirTurnos(DateTime fechaDesde, DateTime fechaHasta)
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

        private static List<Models.TurnosModel> DevolverListaTurnos()
        {


            return ADTurnos.devolverLista();

        }

        public static List<SelectListItem> DevolverListaItems()
        {

            List<Models.TurnosModel> lista = DevolverListaTurnos();
            List<SelectListItem> items = null;
            items = lista.ConvertAll(db =>
            {
                return new SelectListItem()
                {
                    Text = db.fecha + " " + db.hora,
                    Value = db.Id.ToString(),
                    Selected = false
                };

            });


            return items;
        }
    }
}