using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Reserva.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
  
        public string Nombre { get; set; }
        
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool EsAdmin { get; set; }

    }
}