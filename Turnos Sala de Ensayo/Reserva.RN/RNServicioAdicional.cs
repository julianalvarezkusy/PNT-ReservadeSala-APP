using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Datos;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class RNServicioAdicional
    {
        public static List<ServicioAdicional> obtenerServicio()
        {
            return ADServicios.devolverServicio();
        }
    }
}