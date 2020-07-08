﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class SeleccionSalasController : Controller
    {
        // GET: SeleccionSalas
        public ActionResult Index()
        {

            ViewBag.sala = RNSalas.devolverSala();
            return View();
        }
    }
}