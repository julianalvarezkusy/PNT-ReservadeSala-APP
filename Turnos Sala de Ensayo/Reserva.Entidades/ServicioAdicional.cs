using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Turnos_Sala_de_Ensayo.Reserva.Entidades
{
    public class ServicioAdicional
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public String Descripcion { get; set; }

        public ServicioAdicional(int id, String nombre, double precio, String descripcion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Descripcion = descripcion;
        }
        public ServicioAdicional()
        {
        }
    }
}