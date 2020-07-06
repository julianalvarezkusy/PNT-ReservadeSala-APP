using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public class ADServicios
    {
        public static List<Models.ServicioAdicionalModel> devolverServicio()
        {
            using (Contexto c = new Contexto())
            {
                List<Models.ServicioAdicionalModel> listaServicios = null;
                listaServicios =
                   (from db in c.ServicioAdicional
                    select new ServicioAdicionalModel
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
