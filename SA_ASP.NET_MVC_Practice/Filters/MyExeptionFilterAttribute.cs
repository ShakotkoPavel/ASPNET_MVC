using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SA_ASP.NET_MVC_Practice.Filters
{
    public class MyExeptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is ProductIsNotFoundByIdException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectToRouteResult((RouteTable.Routes["Default"] as Route)?.Defaults);
            }
        }
    }
}