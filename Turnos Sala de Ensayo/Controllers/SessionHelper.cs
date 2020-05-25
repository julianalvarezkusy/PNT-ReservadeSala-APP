using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class SessionHelper : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if(SessionHelper.UsuarioLogueado == null)
            {
                if (filterContext.Controller is LoginController == false || filterContext.Controller is HomeController == false)
                {
                    filterContext.HttpContext.Response.Redirect("/Login/Login");

                }
            }
        }
        public static Usuario UsuarioLogueado
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] == null)
                    return null;
                return (Usuario)HttpContext.Current.Session["Usuario"];
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }

        public static bool ExisteAlguienLogueado
        {

            get
            {
                return (SessionHelper.UsuarioLogueado != null);
            }
        
        }

    }
}