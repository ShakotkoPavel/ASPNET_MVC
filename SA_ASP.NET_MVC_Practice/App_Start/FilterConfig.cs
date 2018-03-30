using System.Web;
using System.Web.Mvc;

namespace SA_ASP.NET_MVC_Practice
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
