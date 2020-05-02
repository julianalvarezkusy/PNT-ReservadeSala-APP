using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Datos;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public static class RNUsuario
    {
        public static List<Usuario> buscar()
        {
            return ADUsuario.buscar();
        }

        public static Usuario buscar (String nombre, String password)
        {
            return ADUsuario.buscar(nombre, password);
        }
    }
}