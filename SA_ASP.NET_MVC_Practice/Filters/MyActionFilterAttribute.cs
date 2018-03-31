using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA_ASP.NET_MVC_Practice.Models;

namespace SA_ASP.NET_MVC_Practice.Filters
{
    public class MyActionFilterAttribute : FilterAttribute, IActionFilter
    {
        DateTime startTime;
        Stopwatch sw;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            sw.Stop();
            if(filterContext.Exception == null)
            {
                Context context = new Context();
                Log log = new Log()
                {
                    StartTime = startTime,
                    EndTime = DateTime.Now,
                    Milliseconds = sw.Elapsed.Milliseconds,
                    NameActionMethod = filterContext.ActionDescriptor.ActionName
                };
                context.Logs.Add(log);
                context.SaveChanges();
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            startTime = DateTime.Now;
            sw = Stopwatch.StartNew();
        }
    }
}