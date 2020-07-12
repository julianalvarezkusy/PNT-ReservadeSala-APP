using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Datos;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class GestorDeReserva
    {
        public static bool PuedoReservar(int idSala, 
            int idTurno)
        {
            //var turno = ADTurnos.Buscar(fecha, hora);
            var reserva = ADReservasDeSalas.Buscar(idSala, idTurno);
            if (reserva == null)
                return true;
            return false;
        }

        public static void ConstruirTurnos(DateTime fechaDesde, DateTime fechaHasta)
        {
            DateTime fecha = DameLunes(fechaDesde);
            DateTime fechaHastaNueva = fecha.AddDays(6);
            do
            {
                for (int i = 18; i <= 23; i++)
                {
                    ADTurnos.Agregar(
                        new Entidades.Turno()
                        {
                            Fecha = fecha,
                            Hora = i
                        }
                        );
                    //ADTurnos.Agregar(
                    //    new Entidades.Turno()
                    //    {
                    //        Fecha = fecha,
                    //        Hora = i + 0.5M
                    //    }
                    //    );
                }
                fecha = fecha.AddDays(1);
            } while (fecha != fechaHastaNueva);
        }

        public static void ConstruirTurnos()
        {

            ADTurnos.Agregar(new Turno()
            {
                Fecha = DateTime.Now.AddDays(-7),
                Hora = 18

            }
                ); 

            DateTime fechaDesde = ObtenerUltimaFecha();

            DateTime fechaHastaNueva = fechaDesde.AddDays(30);
            do
            {
                for (int i = 18; i <= 23; i++)
                {
                    ADTurnos.Agregar(
                        new Entidades.Turno()
                        {
                            Fecha = fechaDesde,
                            Hora = i
                        }
                        );

                }
                fechaDesde = fechaDesde.AddDays(1);
            } while (fechaDesde != fechaHastaNueva);
        }

        private  static DateTime ObtenerUltimaFecha()
        {
            DateTime UltimaFecha = ADTurnos.ObtenerUltimaFecha();

            return UltimaFecha;
        }

        //Método deprecado
        private static List<Models.TurnosModel> DevolverListaTurnos(int idSala)
        {

           return ADTurnos.devolverLista(idSala);

        }

        public static List<Models.TurnosModel> DevolverListaTurnos(int idSala, DateTime fechaIni, DateTime fechaFin)
        {
            return ADTurnos.devolverLista(idSala, fechaIni, fechaFin);
        }

        public static List<Models.TurnosModel> DevolverListaTurnosOcupados(int idSala, DateTime fechaIni, DateTime fechaFin)
        {
            return ADTurnos.DevolverTurnosOcupados(idSala, fechaIni, fechaFin);
        }

        //Método deprecado
        public static List<SelectListItem> DevolverListaItems(int idSala)
        {

            //List<Models.TurnosModel> lista = DevolverListaTurnos();
            List<Models.TurnosModel> lista = ADTurnos.devolverLista(idSala);
            List<SelectListItem> items = null;
            items = lista.ConvertAll(db =>
            {
                return new SelectListItem()
                {
                    Text = db.fecha + " ," + db.hora + "hs.",
                    Value = db.Id.ToString(),
                    Selected = false
                };

            });


            return items;
        }

        //Método deprecado
        public static List<SelectListItem> DevolverListaItems(int idSala, DateTime fechaIni, DateTime fechaFin)
        {
            List<Models.TurnosModel> lista = ADTurnos.devolverLista(idSala,fechaIni, fechaFin);
            List<SelectListItem> items = null;
            items = lista.ConvertAll(db =>
            {
                return new SelectListItem()
                {
                    Text = db.fecha + " ," + db.hora + "hs.",
                    Value = db.Id.ToString(),
                    Selected = false
                };

            });


            return items;
        }

        public static Models.TurnosModel[,] DevolverMatrizDeTurnos(int idSala, DateTime fechaIni, DateTime fechaFin)
        {
            List<Models.TurnosModel> listaDeTurnos = ADTurnos.devolverLista( idSala,  fechaIni, fechaFin);
            Models.TurnosModel[,] matrizDeTurnos = new Models.TurnosModel[6,7];

            int PosicionDia;
            int PosicionHora;
            
            foreach(Models.TurnosModel turno in listaDeTurnos)
            {
                switch (Convert.ToDateTime(turno.fecha).DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        PosicionDia = 0;
                        break;
                    case DayOfWeek.Tuesday:
                        PosicionDia = 1;
                        break;
                    case DayOfWeek.Wednesday:
                        PosicionDia = 2;
                        break;
                    case DayOfWeek.Thursday:
                        PosicionDia = 3;
                        break;
                    case DayOfWeek.Friday:
                        PosicionDia = 4;
                        break;
                    case DayOfWeek.Saturday:
                        PosicionDia = 5;
                        break;
                    case DayOfWeek.Sunday:
                        PosicionDia = 6;
                        break;
                    default:
                        PosicionDia = -1;
                        break;
                }
                decimal hora = Convert.ToDecimal(turno.hora);
                switch (turno.hora)
                {
                    case "18.00":
                        PosicionHora = 0;
                        break;
                    case "19.00":
                        PosicionHora = 1;
                        break;
                    case "20.00":
                        PosicionHora = 2;
                        break;
                    case "21.00":
                        PosicionHora = 3;
                        break;
                    case "22.00":
                        PosicionHora = 4;
                        break;
                    case "23.00":
                        PosicionHora = 5;
                        break;
                    default:
                        PosicionHora = -1;
                        break;
                }

                if(PosicionDia != -1 && PosicionHora != -1)
                {
                    matrizDeTurnos[PosicionHora, PosicionDia] = turno;
                }
                
            }


            return matrizDeTurnos;

        }

        //Método deprecado
        /*
        public static List<SelectListItem> DevolverListaSalas()
        {
            List<Sala> listaDeSalas = ADSalas.Buscar();

            List<SelectListItem> items = null;

            items = listaDeSalas.ConvertAll(db =>
            {
                return new SelectListItem()
                {
                    Text = db.Nombre,
                    Value = db.Id.ToString(),
                    Selected = false
                };
            });
            return items; 
        }*/

        public static Turno BuscarTurno(int idTurno)
        {
            return ADTurnos.Buscar(idTurno);
        }

        public static void Reservar(int idSala, int usuario, int turno, List<ServicioAdicionalModel> servicios)
        {
            List<ServicioAdicional> listaServicios = new List<ServicioAdicional>();
            listaServicios = obtenerServicios(servicios);
            ADReservasDeSalas.Reservar(new ReservaDeSala(idSala, usuario, turno, listaServicios));

            agregarAdicionales(listaServicios);

           
            
        }


        private static void agregarAdicionales (List<ServicioAdicional> servicios)
        {
            int IdReserva = ADReservasDeSalas.obtenerReserva();
            ADReservasDeSalas.agregarAdicionales(new ReservaAdicional(IdReserva, servicios));

            
        }

        private static List<ServicioAdicional> obtenerServicios(List <ServicioAdicionalModel> lista)
        {
            List<ServicioAdicional> retorno = new List<ServicioAdicional>();
            foreach (ServicioAdicionalModel servicio in lista ){
                retorno.Add(new ServicioAdicional(servicio.Id, servicio.Nombre, servicio.Precio, servicio.Descripcion, servicio.Cantidad));
            }

            return retorno;
        }

        public static DateTime DameLunes(DateTime fechaActual)
        {
            var diaActual = fechaActual.DayOfWeek;
            
            while (!diaActual.Equals(DayOfWeek.Monday))
            {
                fechaActual = fechaActual.AddDays(-1);
                diaActual = fechaActual.DayOfWeek;
            }
            return fechaActual;
        }

        public static Models.TurnosModel[,] AvanzarSemana(int idSala, DateTime fechaDesde)
        {
            DateTime FechaInicio = fechaDesde.AddDays(1);
            DateTime FechaFin = FechaInicio.AddDays(6);

            Models.TurnosModel[,] listaTurnos = DevolverMatrizDeTurnos(idSala, FechaInicio, FechaFin);

            return listaTurnos;
            
         }

        public static List<Models.ReservaDatosModel> DevolverListaReservas()
        {
            return ADReservasDeSalas.DevolverListaReservas();
        }

    }
}