using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class IndicadoresController : Controller
    {
        // GET: Indicadores
        public ActionResult Index()
        {
            String[] Fechas = ObtenerDias();
            DateTime FechaInicio = Convert.ToDateTime("01/06/2020");
            DateTime FechaFin= Convert.ToDateTime("30/06/2020"); ;
            int[] CantTurnosPorFecha = RNIndicadores.DevolverCantTurnosOcupados(1, FechaInicio, FechaFin);
            //String Turnos;

            ViewBag.Fechas = Fechas;

            

            ViewBag.Turnos = CantTurnosPorFecha;

            return View();
        }


        public static String[] ObtenerDias()
        {
            //DateTime Fecha = DateTime.Today;

            //int Mes = Fecha.Month;

            String[] Fechas = new string[30];

           // String Comillas = "\"";

            for (int i = 0; i < Fechas.Length; i++){
                //Fechas = Fechas + Comillas + (i+1) + "/6" + Comillas + ",";

                //Fechas = String.Concat(Fechas, "\"", (i + 1).ToString(), "/6\",");

                Fechas[i] = (i + 1) + "/6";


            }

            

            return Fechas;

        }

        

    }
}