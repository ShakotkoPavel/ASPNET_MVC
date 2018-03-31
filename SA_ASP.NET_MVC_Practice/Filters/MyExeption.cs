using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_ASP.NET_MVC_Practice.Filters
{
    public class ProductNotFoundByIdException : Exception
    {
        public ProductNotFoundByIdException()
        {
        }

        public ProductNotFoundByIdException(string message)
            : base(message)
        {
        }
    }
}