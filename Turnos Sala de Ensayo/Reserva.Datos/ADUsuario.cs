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
            /*return BaseDeDatos.ListaUsuarios.Where(
                usuario => usuario.Username == nombre && usuario.Password == password).FirstOrDefault();*/

            Contexto context = new Contexto();

            return context.Usuarios.Where(
                usuario => usuario.Username == nombre && usuario.Password == password).FirstOrDefault();
                
        }

        public static Usuario buscar(String username)
        {
            Contexto context = new Contexto();

            return context.Usuarios.Where(
                usuario => usuario.Username == username).FirstOrDefault();
        }

 

        public static Usuario agregar(Usuario usuario)
        {

            Contexto contexto = new Contexto();

            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();


            return usuario;
        }
    }
}