using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VincentRestorant.Models;


namespace VincentRestorant.ViewModel
{
    public class Contacts
    {
        public List<Adres_First> adres { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> prop { get; set; }
    }
}