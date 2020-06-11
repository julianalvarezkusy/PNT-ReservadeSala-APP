using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class SeleccionHorarioController : Controller
    {
        // GET: SeleccionHorario
        public ActionResult Index(int idSala)
        {

            var hoy = GestorDeReserva.DameLunes(DateTime.Today);
            

            var fechaFin = hoy.AddDays(6);

            List<Models.TurnosModel> Horarios = GestorDeReserva.DevolverListaTurnos(idSala, hoy, fechaFin);

            Models.TurnosModel[,] matrizDeTurnos = GestorDeReserva.DevolverMatrizDeTurnos(idSala, hoy, fechaFin);

            ViewBag.Horarios = Horarios;

            ViewBag.MatrizTurnos = matrizDeTurnos;

            ViewBag.idSala = idSala;
            
            ViewBag.Lunes = hoy + "||"+ fechaFin;


            return View();
        }


    }
}