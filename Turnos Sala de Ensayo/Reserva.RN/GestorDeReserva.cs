using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.Datos;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class GestorDeReserva
    {
        public static bool PuedoReservar(int idSala, 
            int idTurno)
        {
            //var turno = ADTurnos.Buscar(fecha, hora);
            var reserva = ADReservasDeSalas.Buscar(idSala, idTurno);
            if (reserva == null)
                return true;
            return false;
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
                    //ADTurnos.Agregar(
                    //    new Entidades.Turno()
                    //    {
                    //        Fecha = fecha,
                    //        Hora = i + 0.5M
                    //    }
                    //    );
                }
                fecha = fecha.AddDays(1);
            } while (fecha != fechaHasta);
        }

        private static List<Models.TurnosModel> DevolverListaTurnos(int idSala)
        {

           return ADTurnos.devolverLista(idSala);

        }

        public static List<SelectListItem> DevolverListaItems(int idSala)
        {

            //List<Models.TurnosModel> lista = DevolverListaTurnos();
            List<Models.TurnosModel> lista = ADTurnos.devolverLista(idSala);
            List<SelectListItem> items = null;
            items = lista.ConvertAll(db =>
            {
                return new SelectListItem()
                {
                    Text = db.fecha + " ," + db.hora + "hs.",
                    Value = db.Id.ToString(),
                    Selected = false
                };

            });


            return items;
        }

        public static List<SelectListItem> DevolverListaSalas()
        {
            List<Sala> listaDeSalas = ADSalas.Buscar();

            List<SelectListItem> items = null;

            items = listaDeSalas.ConvertAll(db =>
            {
                return new SelectListItem()
                {
                    Text = db.Nombre,
                    Value = db.Id.ToString(),
                    Selected = false
                };
            });
            return items; 
        }

        public static Turno BuscarTurno(int idTurno)
        {
            return ADTurnos.Buscar(idTurno);
        }

        public static ReservaDeSala Reservar(int idSala, int usuario, int turno)
        {
            
                return ADReservasDeSalas.Reservar(new ReservaDeSala(idSala, usuario, turno));
           
            
        }

        public static DateTime DameLunes(DateTime fechaActual)
        {
            var diaActual = fechaActual.DayOfWeek;
            
            while (!diaActual.Equals(DayOfWeek.Monday))
            {
                fechaActual = fechaActual.AddDays(-1);
                diaActual = fechaActual.DayOfWeek;
            }
            return fechaActual;
        }
    }
}