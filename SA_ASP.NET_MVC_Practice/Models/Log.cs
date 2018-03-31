using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA_ASP.NET_MVC_Practice.Models
{
    public class Log
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Milliseconds { get; set; }

        public string NameActionMethod { get; set; }
    }
}