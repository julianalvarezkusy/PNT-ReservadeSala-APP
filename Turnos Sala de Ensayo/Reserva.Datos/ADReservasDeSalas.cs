using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public static class ADReservasDeSalas
    {
        public static List<ReservaDeSala> Buscar()
        {
            using (Contexto c = new Contexto())
            {
                return c.ReservasDeSalas.ToList();
            }
        }
        public static ReservaDeSala Buscar(int idSala, int idTurno)
        {
            using (Contexto c = new Contexto())
            {
                return c.ReservasDeSalas
                    .Where(o => o.IdSala == idSala &&
                    o.IdTurno == idTurno
                    ).FirstOrDefault();
            }
        }

        public static ReservaDeSala Reservar(ReservaDeSala reserva)
        {
            using(Contexto c = new Contexto())
            {
                c.ReservasDeSalas.Add(reserva);
                c.SaveChanges();
            }
            return reserva;
        }

        public static List<ReservaDatosModel> DevolverListaReservas()
        {
            using(Contexto c = new Contexto())
            {
                List<ReservaDatosModel> lista = null;

                lista = (from reserva in c.ReservasDeSalas
                         join turno in c.Turnos on reserva.IdTurno equals turno.Id
                         join usuario in c.Usuarios on reserva.IdUsuario equals usuario.Id
                         select new ReservaDatosModel
                         {
                             Id = reserva.Id,
                             Fecha = turno.Fecha.ToString(),
                             Hora = turno.Hora.ToString(),
                             Usuario = usuario.Username,
                             IdSala = reserva.IdSala

                         }


                         ).ToList();

                return lista;
            }
        }

        //public static ReservaDeSala Agregar(ReservaDeSala ReservaDeSala)
        //{
        //    using (Contexto c = new Contexto())
        //    {
        //        c.ReservaDeSala.Add(ReservaDeSala);
        //        c.SaveChanges();
        //        return ReservaDeSala;
        //    }

        //}
    }
}