using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class SingproductController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Singproduct
        public ActionResult Index(int? id)
        {
            if (id == null)
            {


                return RedirectToAction("Index", "Home");
            }


            SingleproducVM bnm = new SingleproducVM();
            bnm.products = db.Products.Find(id);
            var test = db.Products.Find(id).Categories_ID;
       


            if (db.Products.Count()>3)
            {
                bnm.prod = db.Products.Where(t=>t.Categories_ID==test).Take(3).ToList();

            }
            else
            {
                bnm.prod = db.Products.ToList();
            }
            bnm.producsize = db.ProductSizes.ToList();
            bnm.sizes=db.Sizes.ToList();
            if (bnm == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Product product = db.Products.Find();
            return View(bnm);
        }
    }
}