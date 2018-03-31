using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_ASP.NET_MVC_Practice.Filters
{
    public class ProductIsNotFoundByIdException : Exception
    {
        public ProductIsNotFoundByIdException()
        {
        }

        public ProductIsNotFoundByIdException(string message)
            : base(message)
        {
        }

        public ProductIsNotFoundByIdException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}