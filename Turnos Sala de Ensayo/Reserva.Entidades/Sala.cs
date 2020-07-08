using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Reserva.Entidades
{
    public class Sala
    {
        public int Id { get; set;  }

        public String Nombre { get; set; }
        public double Precio { get; set; }
        public String Descripcion { get; set; }

        public Sala(String Nombre, double Precio, String Descripcion )
        {
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.Descripcion = Descripcion;
        }

        public Sala()
        {

        }
    }
}