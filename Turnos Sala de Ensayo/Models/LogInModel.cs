using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Models
{
    public class LogInModel
    {
        public String nombreUsuario { get; set; }

        public String password { get; set; }

        public String resultado = "Intente nuevamente.";

    }
}