using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VincentRestorant.Models;


namespace VincentRestorant.ViewModel
{
    public class HomeIndexVM
    {
        public List<Sliderfirst> mainslider { get; set; }
        public  List<Information> information { get; set; }
        public  List<Product>  product { get; set; }
        public List<Product> prop { get; set; }
        public List<Product> propname { get; set; }
        public List<Product> prop2 { get; set; }
        public List<Product> propname2 { get; set; }
        public List<Product> prop3 { get; set; }
        public List<Product> propname3 { get; set; }
        public List<ProductSize> sizeproduct{ get; set; }
        public  List<Size>  sizes { get; set; }
        public  List<Category>  categories { get; set; }
        public List<User> users { get; set; }
        public List<Order> orderss { get; set; }
        public List<Ordersitem> ordersitem { get; set; }
    }
}