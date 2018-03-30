using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA_ASP.NET_MVC_Practice.Models
{
    public enum Type
    {
        Big,
        Medium,
        Small
    }

    public class Product
    {
        [Required]
        [Display(Name = "Product id")]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 100000)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Type of product")]
        public Type ProductType { get; set; }

        public Detail ProductDetails { get; set; }
    }

    [ComplexType]
    public class Detail
    {
        public int DetailId { get; set; }

        public int Lenth { get; set; }

        public int Width { get; set; }

        public int Heigth { get; set; }
    }

    public class Context : DbContext
    {
        public Context() : base("Database") { }

        public DbSet<Product> Products { get; set; }
    }
}