using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Reserva.Entidades
{
    public class Usuario
    {
        public int id { get; set; }
  
        public string nombre { get; set; }
        
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }

    }
}