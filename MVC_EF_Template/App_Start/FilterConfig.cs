using System.Web;
using System.Web.Mvc;

namespace MVC_EF_Template
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new HandleConcurrencyExceptionFilter()); //handler de excepciones de concurrencia! (adam tuliper)
        }
    }
}
