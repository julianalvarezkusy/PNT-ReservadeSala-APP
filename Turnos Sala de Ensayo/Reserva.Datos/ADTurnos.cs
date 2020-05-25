﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Models;
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

        public static List<Turno> BuscarConFiltro()
        {
            using (Contexto c = new Contexto())
            {
                var FechaFin = DateTime.Today; 
                
                return c.Turnos.Where(o=>o.Fecha < DateTime.Today.AddDays(7)).ToList();
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

        public static Turno Buscar(int idTurno)
        {
            using (Contexto c = new Contexto())
            {
                return c.Turnos
                    .Where(o => o.Id == idTurno).FirstOrDefault();


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

        public static List<Models.TurnosModel> devolverLista()
        {
            List<Models.TurnosModel> lista = null;
            using (Contexto c = new Contexto())
            {
                lista =
                   (from db in c.Turnos 
                    select new TurnosModel
                    {
                        Id = db.Id,
                        fecha = db.Fecha.ToString().Substring(0,11),
                        hora = db.Hora.ToString()

                    }).ToList();

            }


            return lista;
        }

    }
}