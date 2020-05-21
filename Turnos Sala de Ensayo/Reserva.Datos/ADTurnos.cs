using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public static class ADTurnos
    {
        public static List<Turno> Buscar()
        {
            using (Contexto c = new Contexto())
            {
                return c.Turnos.ToList();
            }
        }
        public static Turno Buscar(DateTime fecha, decimal hora)
        {
            using (Contexto c = new Contexto())
            {
                return c.Turnos
                    .Where(o => o.Fecha == fecha && 
                    o.Hora == hora).FirstOrDefault();
                    
                    
            }
        }

        public static Turno Agregar(Turno turno)
        {
            using (Contexto c = new Contexto())
            {
                c.Turnos.Add(turno);
                c.SaveChanges();
                return turno;
            }
            
        }
    }
}