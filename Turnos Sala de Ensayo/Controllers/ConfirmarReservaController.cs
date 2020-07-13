using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class ConfirmarReservaController : Controller
    {
        // GET: ConfirmarReserva
        public ActionResult Index(int idTurno, int idSala)
        {
            var fecha = Turnos_Sala_de_Ensayo.Reserva.RN.GestorDeReserva.BuscarTurno(idTurno).Fecha;
            var horaTurno = Turnos_Sala_de_Ensayo.Reserva.RN.GestorDeReserva.BuscarTurno(idTurno).Hora;
            ViewBag.idTurno = idTurno;
            ViewBag.fechaTurno = DateFormat.DateFormater(fecha);
            ViewBag.idSala = idSala;
            ViewBag.idSala1 = idSala;
            ViewBag.horaTurno = horaTurno;
            ViewBag.adicionales = RNServicioAdicional.obtenerServicio();

            ReservaModel modelo = new ReservaModel();
            modelo.IdTurno = idTurno;
            ViewBag.fechaTurno = DateFormat.DateFormater(fecha);
            modelo.IdSala = idSala;
            //modelo.IdUsuario = ;
            modelo.ServiciosAdicionales = RNServicioAdicional.obtenerServicio();

            return View(modelo);
        }

        public ActionResult reservar(Models.ReservaModel modelo)
        {
            int IdUsuario = SessionHelper.UsuarioLogueado.Id;
            GestorDeReserva.Reservar(modelo.IdSala, IdUsuario, modelo.IdTurno, modelo.ServiciosAdicionales);
            Session["Usuario"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}