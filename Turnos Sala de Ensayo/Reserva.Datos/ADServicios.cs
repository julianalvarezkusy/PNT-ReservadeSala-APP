using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public class ADServicios
    {
        public static List<Reserva.Entidades.ServicioAdicional> devolverServicio()
        {
            using (Contexto c = new Contexto())
            {
                List<Reserva.Entidades.ServicioAdicional> listaServicios = null;
                listaServicios =
                   (from db in c.ServicioAdicional
                    select new ServicioAdicional
                    {

                        Id = db.Id,
                        Nombre = db.Nombre,
                        Precio = db.Precio,
                        Descripcion = db.Descripcion
                    }
                    ).ToList();

                return listaServicios;
            }
        }
    }
}
