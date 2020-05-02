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
            var usuario = RNUsuario.buscar(modelo.nombreUsuario, modelo.password);
            
                
                if (usuario != null)
                { 
                    action = RedirectToAction("Index", "SeleccionSalas"); 
                }                    
            
            return action;
        }
    }

    
}