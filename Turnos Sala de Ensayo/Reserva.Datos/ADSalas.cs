using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public class ADSalas
    {
        public static List<Sala> Buscar()
        {
            using(Contexto c = new Contexto())
            {
                return c.salas.ToList();
            }
        }

        public static Sala agregarSala(Sala sala)
        {
            using(Contexto c = new Contexto())
            {
                return c.salas.Add(sala);
            }
        }
    }
}