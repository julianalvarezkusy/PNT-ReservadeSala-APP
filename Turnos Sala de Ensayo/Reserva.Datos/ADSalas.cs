using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public class ADSalas
    {
        /* {
             public static List<Sala> Buscar()
             {
                 using(Contexto c = new Contexto())
                 {
                     return c.Sala.ToList();
                 }
             }

             public static Sala agregarSala(Sala sala)
             {
                 using(Contexto c = new Contexto())
                 {
                     return c.salas.Add(sala);
                 }
             }*/

        public static Models.SalaModel devolverSala(int idSala)
        {
            using (Contexto c = new Contexto())
            {
                Sala salaBuscada = c.Sala.Where(o => o.Id == idSala).FirstOrDefault();
                return new SalaModel
                {
                    Id = salaBuscada.Id,
                    Nombre = salaBuscada.Nombre,
                    Descripcion = salaBuscada.Descripcion,
                    Precio = salaBuscada.Precio
                };
            }
        }

        public static List<Models.SalaModel> devolverSala()
        {
            using (Contexto c = new Contexto())
            {
                List<Models.SalaModel> listaSalas = null;
                listaSalas =
                   (from db in c.Sala
                    select new SalaModel
                    {

                        Id = db.Id,
                        Nombre = db.Nombre,
                        Precio = db.Precio,
                        Descripcion = db.Descripcion
                    }
                    ).ToList();

                return listaSalas;
            }
        }

        public static void crearSala(Sala sala)
        {
            using (Contexto c = new Contexto())
            {

                c.Sala.Add(sala);
                c.SaveChanges();
            }


        }
    }
}