using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA_ASP.NET_MVC_Practice.Models;

namespace SA_ASP.NET_MVC_Practice.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(Product product)
        {
            if (product.ProductId > default(int) && !string.IsNullOrEmpty(product.Name) && product.Price > default(decimal))
            {
                Context context = new Context();
                context.Products.Add(new Product
                {
                    ProductId = product.ProductId,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    ProductType = product.ProductType,
                    ProductDetails = new Detail
                    {
                        Heigth = product.ProductDetails.Heigth,
                        Width = product.ProductDetails.Width,
                        Lenth = product.ProductDetails.Lenth
                    }
                    });
                context.SaveChanges();
            }

            return View();
        }

        public ActionResult ShowById(int? productId)
        {
            if (productId.HasValue)
            {
                var product = new Context().Products.Find(productId);
                if (product != null)
                {
                    ViewBag.Message = $"Product Id = {product.ProductId}, Name = {product.Name}, Price = {product.Price}, Type = {product.ProductType.ToString()}. " +
                        $"Details: Length = {product.ProductDetails.Lenth}" +
                        $"Heigth = {product.ProductDetails.Heigth}" +
                        $"Width = {product.ProductDetails.Width}";
                }
                else
                {
                    ViewBag.Message = $"We haven`t found product by Id#{productId}";
                }
            }

            return View();
        }

        public ActionResult ShowList()
        {
            return View(new Context().Products);
        }
    }
}