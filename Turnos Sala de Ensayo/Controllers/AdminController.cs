using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            List<Models.ReservaDatosModel> Reservas = GestorDeReserva.DevolverListaReservas();

            ViewBag.Reservas = Reservas;

            return View();
        }

        public ActionResult CrearTurnos()
        {
            Reserva.RN.GestorDeReserva.ConstruirTurnos();


            return View("Index");
        }

        public ActionResult CrearSala()
        {
            return RedirectToAction("index", "AgregarSala");
        }
    }
}