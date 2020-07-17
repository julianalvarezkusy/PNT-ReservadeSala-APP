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
    public class EstadisticaFinancieraController : Controller
    {
        // GET: EstadisticaFinanciera
        public ActionResult Index(Models.SalaModel modelo)
        {
            SalaModel sala = null;
            List<SalaModel> salas = RNSalas.devolverSala();

            if(modelo.Id == 0)
            {
                sala = salas.First<SalaModel>();
            }

            Models.GananciaSalaModel[] matrizGanancias = 
            RNEstadisticaFinanciera.DevolverGananciasAnuales(sala.Id);

            ViewBag.MatrizGanancias = matrizGanancias;
            ViewBag.IdSala = sala.Id;
            ViewBag.NombreSala = sala.Nombre;

            return View();
        }

        public ActionResult RetrocederSemana(Models.SalaModel modelo)
        {
            List<SalaModel> salas = RNSalas.devolverSala();
            SalaModel salaPrevia = salas.First<SalaModel>();

            foreach (Models.SalaModel s in salas)
            {
                if (s.Id == modelo.Id)
                {
                    break; 
                }
                salaPrevia = s;
            }

            Models.GananciaSalaModel[] matrizGanancias =
            RNEstadisticaFinanciera.DevolverGananciasAnuales(salaPrevia.Id);

            ViewBag.MatrizGanancias = matrizGanancias;
            ViewBag.IdSala = salaPrevia.Id;
            ViewBag.NombreSala = salaPrevia.Nombre;

            return View("Index",salaPrevia);
        }

        public ActionResult AvanzarSemana(Models.SalaModel modelo)
        {

            List<SalaModel> salas = RNSalas.devolverSala();
            SalaModel salaProxima = salas.Last<SalaModel>();
            Boolean proximo = false;

            foreach (Models.SalaModel s in salas)
            {
                if (s.Id == modelo.Id && !proximo)
                {
                    proximo = true;
                }
                else if(proximo)
                {
                    salaProxima = s;
                    break;
                }
            }

            Models.GananciaSalaModel[] matrizGanancias =
            RNEstadisticaFinanciera.DevolverGananciasAnuales(salaProxima.Id);

            ViewBag.MatrizGanancias = matrizGanancias;
            ViewBag.IdSala = salaProxima.Id;
            ViewBag.NombreSala = salaProxima.Nombre;

            return View("Index", salaProxima);
        }
    }
}