using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{

    public class ServiciosAdicionalesController : Controller
    {

        // GET: ServiciosAdicionales
        public ActionResult Index()
        {
            {
                ViewBag.adicionales = RNServicioAdicional.obtenerServicio();
                return View();
            }
        }
    }
}