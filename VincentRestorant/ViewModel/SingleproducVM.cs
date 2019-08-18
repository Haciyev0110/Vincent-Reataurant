using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VincentRestorant.Models;

namespace VincentRestorant.ViewModel
{
    public class SingleproducVM
    {
        public Product products { get; set; }
        public List<Product> prod { get; set; }
        public List<ProductSize> producsize { get; set; }
        public List<Size> sizes { get; set; }
     
    }
}