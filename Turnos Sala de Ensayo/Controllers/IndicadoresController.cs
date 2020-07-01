using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Controllers
{
    public class IndicadoresController : Controller
    {
        // GET: Indicadores
        public ActionResult Index(FechaModel model)
        {
            DateTime InicioDeLosTiempos = DateTime.MinValue;
            if(model.Fecha == InicioDeLosTiempos)
            {
                model.Fecha = DateTime.Now;
            }

            //estoy probando acá
            int IdMes = model.Fecha.Month;
            int Anio = model.Fecha.Year;
            String[] Fechas = ObtenerDias(model.Fecha.Month, model.Fecha.Year);
            String FInicio = "01/" + IdMes + "/" + Anio;
            int CantDiasMes = DateTime.DaysInMonth(Anio, IdMes);
            String FFin = CantDiasMes + "/" + IdMes + "/" + Anio;
            DateTime FechaInicio = Convert.ToDateTime(FInicio);
            DateTime FechaFin = Convert.ToDateTime(FFin);
            int[] CantTurnosPorFecha = RNIndicadores.DevolverCantTurnosOcupados(1, FechaInicio, FechaFin);
            

            ViewBag.Fechas = Fechas;
            ViewBag.Turnos = CantTurnosPorFecha;
            ViewBag.Mes = GetMes(IdMes);
            ViewBag.Anio = Anio;

            return View();
        }

        public ActionResult graficar(DateTime fecha)
        {

            Models.FechaModel  modelo = new FechaModel();
            modelo.Fecha = fecha;

 


            //return View("Index",modelo);

            return RedirectToAction("Index","Indicadores", modelo);
        }

    


        public static String[] ObtenerDias(int mes, int anio)
        {
            //DateTime Fecha = DateTime.Today;

            //int Mes = Fecha.Month;

            String[] Fechas = new string[DateTime.DaysInMonth(anio,mes)];

           // String Comillas = "\"";

            for (int i = 0; i < Fechas.Length; i++){
                
                Fechas[i] = (i + 1) + "/" + mes;


            }

            

            return Fechas;

        }

        private String GetMes(int numeroMes)
        {
            String Mes = "";
            switch (numeroMes)
            {
                case 1: Mes = "Enero";
                    break;
                case 2: Mes = "Febrero";
                    break;
                case 3: Mes = "Marzo";
                    break;
                case 4: Mes = "Abril";
                    break;
                case 5: Mes = "Mayo";
                    break;
                case 6: Mes = "Junio";
                    break;
                case 7: Mes = "Julio";
                    break;
                case 8: Mes = "Agosto";
                    break;
                case 9: Mes = "Septiembre";
                    break;
                case 10: Mes = "Octubre";
                    break;
                case 11: Mes = "Noviembre";
                    break;
                case 12: Mes = "Diciembre";
                    break;
            }
            return Mes;
        }

        

    }
}