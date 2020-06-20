using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnos_Sala_de_Ensayo.Reserva.RN
{
    public class DateFormat
    {
        public static String DateFormater(DateTime fecha)
        {
            String FechaString = fecha.ToString();

            String[] DateParse = FechaString.Split('/');

            if (DateParse[0].Length == 2 && DateParse[1].Length == 2)
            {
                FechaString =  FechaString.Substring(0, 10);
            }
            else if (DateParse[0].Length == 1 && DateParse[1].Length == 2)
            {
                FechaString = FechaString.Substring(0, 9);
            }
            else if (DateParse[0].Length == 1 && DateParse[1].Length == 1)
            {
                FechaString =  FechaString.Substring(0, 8);
            } else if(DateParse[0].Length == 2 && DateParse[1].Length == 1)
            {
                FechaString =  FechaString.Substring(0, 9);
            }


            return FechaString;
        }

        public static String ShortDateFormater(DateTime fecha)
        {
            String FechaString = fecha.ToString();
            String[] DateParse = FechaString.Split('/');

            if (DateParse[0].Length == 2 && DateParse[1].Length == 2)
            {
                FechaString = FechaString.Substring(0, 5);
            }
            else if (DateParse[0].Length == 1 && DateParse[1].Length == 2)
            {
                FechaString = FechaString.Substring(0, 4);
            }
            else if (DateParse[0].Length == 1 && DateParse[1].Length == 1)
            {
                FechaString = FechaString.Substring(0, 3);
            }
            else if (DateParse[0].Length == 2 && DateParse[1].Length == 1)
            {
                FechaString = FechaString.Substring(0, 4);
            }

            return FechaString;
        }
    }
}