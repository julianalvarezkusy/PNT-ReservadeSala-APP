using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Models;
using Turnos_Sala_de_Ensayo.Reserva.Datos;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class RNEstadisticaFinanciera
    {
        private static String[] matrizMeses = new String[] {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre","Noviembre","Diciembre"};
       
        public static Models.GananciaSalaModel DevolverGanancias(int idSala, DateTime fechaIni, DateTime fechaFin)
        {
            List<Models.ReservaDatosModel> listaReservas = ADReservasDeSalas.DevolverListaReservas(idSala, fechaIni, fechaFin);

            SalaModel sala = ADSalas.devolverSala(idSala);

            var cantidadReservas = 0;

            foreach (Models.ReservaDatosModel turno in listaReservas)
            {
                cantidadReservas++;
            }
            return new GananciaSalaModel
            {
              IdSala = sala.Id,
              NombreSala = sala.Nombre,
              CantidadReservasSala = cantidadReservas,
              GananciasSala = cantidadReservas * sala.Precio,
              MesSala = matrizMeses[fechaIni.Month-1]
            };
        }

        public static Models.GananciaSalaModel [] DevolverGananciasAnuales(int idSala)
        {
            Models.GananciaSalaModel[] matrizGanancias = new Models.GananciaSalaModel[12];

            for (int i = 1; i < 13; i++)
            {
                DateTime fechaInicio = new DateTime(2020, i, 1);

                int ultimoDia;

                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        ultimoDia = 31;
                        break;

                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        ultimoDia = 30;
                        break;

                    case 2:
                        ultimoDia = 29;
                        break;

                    default:
                        ultimoDia = 30;
                        break;
                }

                DateTime fechaFin = new DateTime(2020, i, ultimoDia);
                matrizGanancias [i-1] = DevolverGanancias(idSala, fechaInicio, fechaFin);
            }
            return matrizGanancias;
        }
    }
}