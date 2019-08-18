using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VincentRestorant.Models;


namespace VincentRestorant.ViewModel
{
    public class BasketProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public int CategoriesId { get; set; }
        public decimal Subtotal { get; set; }
        public int ProductsizId { get; set; }
        public int size { get; set; }

    }
}