using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public static ReservaDeSala Buscar(int idSala, Turno turno)
        {
            using (Contexto c = new Contexto())
            {
                return c.ReservasDeSalas
                    .Where(o => o.IdSala == idSala &&
                    o.Turno.Id == turno.Id
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