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
        public ActionResult Index(int idTurno, int idSala)
        {
            var fecha = Turnos_Sala_de_Ensayo.Reserva.RN.GestorDeReserva.BuscarTurno(idTurno).Fecha;
            var horaTurno = Turnos_Sala_de_Ensayo.Reserva.RN.GestorDeReserva.BuscarTurno(idTurno).Hora;
            ViewBag.idTurno = idTurno;
            ViewBag.fechaTurno = DateFormat.DateFormater(fecha);
            ViewBag.idSala = idSala;
            ViewBag.idSala1 = idSala;
            ViewBag.horaTurno = horaTurno;
            return View();
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