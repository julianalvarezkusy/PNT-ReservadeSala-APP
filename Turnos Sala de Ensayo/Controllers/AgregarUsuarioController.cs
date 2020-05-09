using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class AgregarUsuarioController : Controller
    {
        // GET: AgregarUsuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult agregar(Reserva.Entidades.Usuario usuario)
        {
            ActionResult action = RedirectToAction("Login", "Login");
            var user = Reserva.RN.RNUsuario.buscar(usuario.Username);
            if(user == null)
            {
                Turnos_Sala_de_Ensayo.Reserva.RN.RNUsuario.agregar(usuario);
            }
            else{
                ViewBag.MensajeErrorCrearUser = "El nombre de usuario ya existe.";
                action = View("Index");
            }
            

           return  action;
        }
    }
}