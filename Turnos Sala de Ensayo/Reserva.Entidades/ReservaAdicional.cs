using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.RN;

namespace Turnos_Sala_de_Ensayo.Reserva.Entidades
{
    public class ReservaAdicional
    {
        public int id { get; set; }

        public int idReserva { get; set; }

        public List<ServicioAdicional> servicios { get; set; }

        public ReservaAdicional(int idReserva, List<ServicioAdicional> servicios)
        {
            this.idReserva = idReserva;
            this.servicios = servicios;
    }


    }

  
}