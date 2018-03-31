using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SA_ASP.NET_MVC_Practice.Models;

namespace SA_ASP.NET_MVC_Practice
{
    public class Context : DbContext
    {
        public Context() : base("ShopDB")
        {
            //Database.Initialize(false);
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}