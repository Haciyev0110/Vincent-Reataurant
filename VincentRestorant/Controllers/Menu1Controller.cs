using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    
    public class Menu1Controller : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();
        // GET: Menu1
        public ActionResult Index()
        {
            HomeIndexVM mnv = new HomeIndexVM();
            mnv.information = db.Information.ToList();
            mnv.categories = db.Categories.ToList();
            mnv.product = db.Products.ToList();
         
           
            return View(mnv);
        }
    }
}