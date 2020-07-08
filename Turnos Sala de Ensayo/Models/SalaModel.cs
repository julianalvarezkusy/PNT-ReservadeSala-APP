using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Models
{
    public class SalaModel
    {
        public int Id { get; set; }

        public String Nombre { get; set; }

        public double Precio { get; set; }

        public String Descripcion { get; set; }

    }
}