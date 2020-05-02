using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public static class BaseDeDatos
    {
        public static List<Usuario> ListaUsuarios
        {
            get;
            set;
        } = new List<Usuario>()
        {
            new Usuario()
            {
                id = 1,
                nombre = "Julian",
                apellido = "Alvarez",
                usuario = "julian",
                password = "123"
            }
        };
    }
    
}