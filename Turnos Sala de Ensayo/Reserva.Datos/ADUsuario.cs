using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public static class ADUsuario
    {
        public static List<Usuario> buscar()
        {
            return BaseDeDatos.ListaUsuarios;
        }

        public static Usuario buscar(String nombre, String password)
        {
            return BaseDeDatos.ListaUsuarios.Where(
                usuario => usuario.usuario == nombre && usuario.password == password).FirstOrDefault();
                
        }
    }
}