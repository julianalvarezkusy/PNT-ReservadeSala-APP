using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class ConfirmarReservaController : Controller
    {
        // GET: ConfirmarReserva
        public ActionResult Index(Models.TurnoSalaModel modelo)
        {
            var fecha = Turnos_Sala_de_Ensayo.Reserva.RN.GestorDeReserva.BuscarTurno(modelo.IdTurno).Fecha;
            var horaTurno = Turnos_Sala_de_Ensayo.Reserva.RN.GestorDeReserva.BuscarTurno(modelo.IdTurno).Hora;
            ViewBag.idTurno = modelo.IdTurno;
            ViewBag.fechaTurno = DateFormat.DateFormater(fecha);
            ViewBag.idSala = modelo.IdSala;
            ViewBag.idSala1 = modelo.IdSala;
            ViewBag.horaTurno = horaTurno;
            ViewBag.adicionales = RNServicioAdicional.obtenerServicio();

            //Traer todas las salas. Mariano
            ViewBag.salas = RNSalas.devolverSala();
            return View();
        }

        public ActionResult modificar(Models.TurnoSalaModel modelo)
        {
            var fecha = Turnos_Sala_de_Ensayo.Reserva.RN.GestorDeReserva.BuscarTurno(modelo.IdTurno).Fecha;
            var horaTurno = Turnos_Sala_de_Ensayo.Reserva.RN.GestorDeReserva.BuscarTurno(modelo.IdTurno).Hora;
            ViewBag.idTurno = modelo.IdTurno;
            ViewBag.fechaTurno = DateFormat.DateFormater(fecha);
            ViewBag.idSala = modelo.IdSala;
            ViewBag.idSala1 = modelo.IdSala;
            ViewBag.horaTurno = horaTurno;
            ViewBag.adicionales = RNServicioAdicional.obtenerServicio();

            //Traer todas las salas.
            ViewBag.salas = RNSalas.devolverSala();
            return View("Index", modelo);
        }

        public ActionResult reservar(Models.ReservaModel modelo)
        {
            int IdUsuario = SessionHelper.UsuarioLogueado.Id;
            GestorDeReserva.Reservar(modelo.IdSala, IdUsuario, modelo.IdTurno);
            Session["Usuario"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}