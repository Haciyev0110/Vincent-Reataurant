using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VincentRestorant.ViewModel
{
    public class SizeViewModel
    {
        public string Name { get; set; }
        public int Categories_ID { get; set; }
        public string Mini_text { get; set; }
        public string Big_text { get; set; }
        public HttpPostedFileBase Img_producr { get; set; }
        
    }

    public class ProductSize1
    {
        public  List<int> SizeId { get; set; }
        public  List<decimal> Price { get; set; }
    }
}