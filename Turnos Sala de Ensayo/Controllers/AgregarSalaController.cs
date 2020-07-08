using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class AgregarSalaController : Controller
    {
        // GET: AgregarSala
        public ActionResult Index()
        {
            return View();
        }

        public void CrearSala(Sala sala)
        {
            RNSalas.crearSala(sala);
        }
        
    }
}