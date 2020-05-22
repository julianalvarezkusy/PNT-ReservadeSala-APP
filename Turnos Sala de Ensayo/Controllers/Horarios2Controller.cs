using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Datos;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class Horarios2Controller : Controller
    {
        // GET: Horarios2
        public ActionResult Index()
        {

           List<SelectListItem> items = GestorDeReserva.DevolverListaItems();

            ViewBag.items = items;

            return View();
        }

        public void CrearTurnos()
        {
            Reserva.RN.GestorDeReserva.ConstruirTurnos(DateTime.Today.AddDays(-10), DateTime.Today);

        }
    }
}