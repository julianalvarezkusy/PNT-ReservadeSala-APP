using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Datos;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class Horarios2Controller : Controller
    {
        // GET: Horarios2
        public ActionResult Index(int idSala)
        {

           List<SelectListItem> items = GestorDeReserva.DevolverListaItems(idSala);

            List<SelectListItem> itemsSala = GestorDeReserva.DevolverListaSalas();

            ViewBag.idSala = idSala;
            ViewBag.items = items;
            ViewBag.itemsSala = itemsSala;

            if (TempData["mensaje"] != null)
                ViewBag.MensajeError = TempData["mensaje"].ToString();




            return View();
        }

        public void CrearTurnos()
        {
            Reserva.RN.GestorDeReserva.ConstruirTurnos(DateTime.Today, DateTime.Today.AddDays(+10));

        }

        public ActionResult Reservar(ReservaModel modelo)
        {
            int usuario = SessionHelper.UsuarioLogueado.Id;
            ActionResult action = null ;


            //Turno turno = GestorDeReserva.BuscarTurno(modelo.IdTurno);
            if(GestorDeReserva.PuedoReservar(modelo.IdSala, modelo.IdTurno))
                {
                GestorDeReserva.Reservar(modelo.IdSala, usuario, modelo.IdTurno);
                action = RedirectToAction("Index", "Home");

            } 
        else
            {
                TempData["mensaje"] = "Seleccione otro Horario.";
                action = RedirectToAction("Index", "Horarios2");
            }

            return action;
        }


    }
}