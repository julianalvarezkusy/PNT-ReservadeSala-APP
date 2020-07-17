using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class SeleccionHorarioController : Controller
    {
        // GET: SeleccionHorario
        public ActionResult Index(SemanaModel modelo)
        {
            DateTime InicioDeLosTiempos = new DateTime();
            if(modelo.FechaInicio == InicioDeLosTiempos)
            {
                modelo.FechaInicio = GestorDeReserva.DameLunes(DateTime.Today);
            }

            modelo.FechaFin = modelo.FechaInicio.AddDays(6);
            modelo.MatrizDeTurnos = GestorDeReserva.DevolverMatrizDeTurnos(modelo.IdSala, modelo.FechaInicio, modelo.FechaFin);

            ViewBag.Lunes = DateFormat.DateFormater(modelo.FechaInicio) + " - " + DateFormat.DateFormater(modelo.FechaFin);
            ViewBag.idSala = modelo.IdSala;
            ViewBag.nombreSala = modelo.NombreSala;
            ViewBag.MatrizTurnos = modelo.MatrizDeTurnos;
            ViewBag.FechaFin = modelo.FechaFin;
            ViewBag.FechaInicio = modelo.FechaInicio;
            ViewBag.WeekDays = WeekDays();
            ViewBag.TurnHours = TurnHours();
            ViewBag.Dates = GetWeekDays(modelo.FechaInicio, modelo.FechaFin);

            return View();
        }

        public ActionResult AvanzarSemana(Models.SemanaModel modelo)
        {
                      
            modelo.FechaInicio = modelo.FechaFin.AddDays(1);
            modelo.FechaFin = modelo.FechaInicio.AddDays(6);
            Models.TurnosModel[,] matrizDeTurnos = GestorDeReserva.DevolverMatrizDeTurnos(modelo.IdSala, modelo.FechaInicio, modelo.FechaFin);
            
            ViewBag.MatrizTurnos = matrizDeTurnos;
            ViewBag.idSala = modelo.IdSala;
            ViewBag.nombreSala = modelo.NombreSala;
            ViewBag.FechaInicio = modelo.FechaInicio;
            ViewBag.FechaFin = modelo.FechaFin;
            ViewBag.Lunes = DateFormat.DateFormater(modelo.FechaInicio) + " - " + DateFormat.DateFormater(modelo.FechaFin);
            ViewBag.WeekDays = WeekDays();
            ViewBag.TurnHours = TurnHours();
            ViewBag.Dates = GetWeekDays(modelo.FechaInicio, modelo.FechaFin);

            return View("Index", modelo);
        }

        public ActionResult RetrocederSemana(Models.SemanaModel modelo)
        {
  
            modelo.FechaInicio = modelo.FechaInicio.AddDays(-7);
            modelo.FechaFin = modelo.FechaInicio.AddDays(6);
            Models.TurnosModel[,] matrizDeTurnos = GestorDeReserva.DevolverMatrizDeTurnos(modelo.IdSala, modelo.FechaInicio, modelo.FechaFin);

            ViewBag.MatrizTurnos = matrizDeTurnos;
            ViewBag.idSala = modelo.IdSala;
            ViewBag.nombreSala = modelo.NombreSala;
            ViewBag.FechaInicio = modelo.FechaInicio;
            ViewBag.FechaFin = modelo.FechaFin;
            ViewBag.Lunes = DateFormat.DateFormater(modelo.FechaInicio) + " - " + DateFormat.DateFormater(modelo.FechaFin);
            ViewBag.WeekDays = WeekDays();
            ViewBag.TurnHours = TurnHours();
            ViewBag.Dates = GetWeekDays(modelo.FechaInicio, modelo.FechaFin);

            return View("Index", modelo);
        }

        private String[] WeekDays()
        {
            return  new string[] { "Horario","Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

        }

        private String[] TurnHours()
        {
            return new String[] { "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" };
        }

        private String[] GetWeekDays(DateTime fechaInicio, DateTime fechaFin)
        {
            DateTime fecha = fechaInicio;
            String[] Dias = new string[(fechaFin - fechaInicio).Days +2];
            Dias[0] = "";
            for(int i = 1; i < Dias.Length; i++)
            {
                Dias[i] = DateFormat.ShortDateFormater(fecha);
                fecha = fecha.AddDays(1);
            }

            return Dias;

        }

    }
}