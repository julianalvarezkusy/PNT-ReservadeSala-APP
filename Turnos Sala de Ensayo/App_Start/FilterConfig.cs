using System.Web;
using System.Web.Mvc;

namespace Turnos_Sala_de_Ensayo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new Controllers.SessionHelper());
        }
    }
}
