using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class SeleccionHorarioController : Controller
    {
        // GET: SeleccionHorario
        public ActionResult Index()
        {
            var hoy = GestorDeReserva.DameLunes(DateTime.Today);
            

            var fechaFin = hoy.AddDays(6);

            ViewBag.Lunes = hoy + "||"+ fechaFin;


            return View();
        }


    }
}