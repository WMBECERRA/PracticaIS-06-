using System.Web;
using System.Web.Mvc;

namespace Practica_06_IS_Cliente02
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
