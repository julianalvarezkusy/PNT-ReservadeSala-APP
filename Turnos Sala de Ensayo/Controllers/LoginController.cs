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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Loguearse(LogInModel modelo)
        {

            ActionResult action = View("Login");

            //Acá busco el usuario que se va a conectar y valido contra la base de datos
            var usuario = RNUsuario.buscar(modelo.nombreUsuario, modelo.password);
            
                action = RedirectToAction("Index", "SeleccionSalas");
                if (usuario == null)
                { 
                    ViewBag.MensajeErrorLogin = "Usuario o Password incorrecto.";
                    action = View("Login");
                     
                }                    
            
            return action;
        }
    }

    
}