using System;
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

        public static List<Models.TurnosModel> devolverLista(int idSala)
        {
            
            using (Contexto c = new Contexto())
            {
                List<Models.TurnosModel> listaTurnosAPartirDeHoy = null;
                listaTurnosAPartirDeHoy =
                   (from db in c.Turnos 
                    where db.Fecha >= DateTime.Now
                    select new TurnosModel
                    {
                        Id = db.Id,
                        fecha = db.Fecha.ToString().Substring(0,11),
                        hora = db.Hora.ToString()

                    })
                    .ToList();

                
                var listaIdTurnos = listaTurnosAPartirDeHoy.Select(o => o.Id).ToList();
                var listaReservasTurnosApartirDeHoy = c.ReservasDeSalas.Where(o => listaIdTurnos.Contains(o.IdTurno)).ToList();
                var listaReservasTurnosAPartirDeHoyPorSala = listaReservasTurnosApartirDeHoy.Where(o => o.IdSala == idSala).ToList();
                var listaIdTurnosYaOcupados = listaReservasTurnosAPartirDeHoyPorSala.Select(o => o.IdTurno).ToList();
                return listaTurnosAPartirDeHoy.Where(o => !listaIdTurnosYaOcupados.Contains(o.Id)).ToList();
            }
            
        }

        public static List<Models.TurnosModel> devolverLista(int idSala, DateTime fechaIni, DateTime fechaFin)
        {

            using (Contexto c = new Contexto())
            {
                List<Models.TurnosModel> listaTurnosAPartirDeHoy = null;
                listaTurnosAPartirDeHoy =
                   (from db in c.Turnos
                    where db.Fecha >= fechaIni && db.Fecha <= fechaFin
                    select new TurnosModel
                    {
                        Id = db.Id,
                        fecha = db.Fecha.ToString().Substring(0, 11),
                        hora = db.Hora.ToString()

                    })
                    .ToList();


                var listaIdTurnos = listaTurnosAPartirDeHoy.Select(o => o.Id).ToList();
                var listaReservasTurnosApartirDeHoy = c.ReservasDeSalas.Where(o => listaIdTurnos.Contains(o.IdTurno)).ToList();
                var listaReservasTurnosAPartirDeHoyPorSala = listaReservasTurnosApartirDeHoy.Where(o => o.IdSala == idSala).ToList();
                var listaIdTurnosYaOcupados = listaReservasTurnosAPartirDeHoyPorSala.Select(o => o.IdTurno).ToList();
                return listaTurnosAPartirDeHoy.Where(o => !listaIdTurnosYaOcupados.Contains(o.Id)).ToList();
            }

        }

        public static List<Turno> devolverListaDeTurnos(int idSala, DateTime fechaIni, DateTime fechaFin)
        {

            using (Contexto c = new Contexto())
            {
                List<Turno> listaTurnosAPartirDeHoy = null;
                listaTurnosAPartirDeHoy =
                   (from db in c.Turnos
                    where db.Fecha >= fechaIni && db.Fecha <= fechaFin
                    select new Turno
                    {
                        Id = db.Id,
                        Fecha = db.Fecha,
                        Hora = db.Hora

                    })
                    .ToList();


                var listaIdTurnos = listaTurnosAPartirDeHoy.Select(o => o.Id).ToList();
                var listaReservasTurnosApartirDeHoy = c.ReservasDeSalas.Where(o => listaIdTurnos.Contains(o.IdTurno)).ToList();
                var listaReservasTurnosAPartirDeHoyPorSala = listaReservasTurnosApartirDeHoy.Where(o => o.IdSala == idSala).ToList();
                var listaIdTurnosYaOcupados = listaReservasTurnosAPartirDeHoyPorSala.Select(o => o.IdTurno).ToList();
                return listaTurnosAPartirDeHoy.Where(o => !listaIdTurnosYaOcupados.Contains(o.Id)).ToList();
            }

        }

    }
}