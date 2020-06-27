using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
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

        public Usuario UsuarioLogueado
        {
            get
            {
                if (Session["Usuario"] == null)
                    return null;
                return (Usuario)Session["Usuario"];
            }
            set
            {
                Session["Usuario"] = value;
            }
        }
        public ActionResult Loguearse(LogInModel modelo)
        {
            Session["Usuario"] = null;

            ActionResult action = RedirectToAction("Index", "SeleccionSalas");
            Usuario usuario = null;


            // Primero valido que no haya nadie logueado
            if (this.UsuarioLogueado != null)
            {

            }
            else
            // SI no hay nadie logueado
            {
                //Busco el usuario en la base de datos
                usuario = RNUsuario.buscar(modelo.nombreUsuario, modelo.password);
                if (usuario == null)
                {
                    ViewBag.MensajeErrorLogin = "Usuario o Password incorrecto.";
                    action = View("Login");
                }
                else
                {
                    this.UsuarioLogueado = usuario;

                    if (UsuarioLogueado.EsAdmin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    
                     
                }
            }
         
         

            
            return action;
        }

        
    }

    
}