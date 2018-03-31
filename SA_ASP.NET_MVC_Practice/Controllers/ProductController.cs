using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA_ASP.NET_MVC_Practice.Models;
using System.Text.RegularExpressions;
using SA_ASP.NET_MVC_Practice.Filters;

namespace SA_ASP.NET_MVC_Practice.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [MyActionFilter]
        public ActionResult Add(Product product)
        {
            if (product.ProductId > default(int) && !string.IsNullOrEmpty(product.Name) && product.Price > default(decimal))
            {

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

        [MyActionFilter]
        [MyExeptionFilter]
        public ActionResult ShowById(int? productId)
        {
            //if (ModelState.IsValid)
            //{
                if (productId.HasValue)
                {
                    var product = new Context().Products.Find(productId);
                    if (product != null)
                    {
                        return View(product);
                        //ViewBag.Message = $"Product Id = {product.ProductId}, Name = {product.Name}, Price = {product.Price}, Type = {product.ProductType.ToString()}. " +
                        //    $"Details: Length = {product.ProductDetails.Lenth}" +
                        //    $" Heigth = {product.ProductDetails.Heigth}" +
                        //    $" Width = {product.ProductDetails.Width}";
                    }
                    else
                    {
                        //TODO Fixed this exception
                        //throw new ProductIsNotFoundByIdException($"We haven`t found product by Id#{productId}");
                        ViewBag.Message = $"The product by Id - {productId} was not found!";
                    }
                }
            //}

            return View();
        }

        [OutputCache(Duration = 300)]
        [MyActionFilter]
        public ActionResult ShowList()
        {
            return View(new Context().Products);
        }

        [HttpGet]
        public ActionResult Check(string name)
        {
            var result = Regex.IsMatch(name, "^[a-zA-Z0-9 ]*$", RegexOptions.IgnoreCase);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}