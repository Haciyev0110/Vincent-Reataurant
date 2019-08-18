using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class Menu3Controller : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();
        // GET: Menu3
        public ActionResult Index()
        {
            HomeIndexVM mnv = new HomeIndexVM();
            mnv.information = db.Information.ToList();
            mnv.categories = db.Categories.ToList();
            mnv.product = db.Products.ToList();
            mnv.propname = db.Products.Where(m => m.Categories_ID == 5).OrderBy(i => i.ID).Skip(2).Take(8).ToList();
            mnv.propname2 = db.Products.Where(m => m.Categories_ID == 6).OrderBy(i => i.ID).Skip(2).Take(8).ToList();
            mnv.propname3 = db.Products.Where(m => m.Categories_ID == 4).OrderBy(i => i.ID).Skip(2).Take(8).ToList();


            return View(mnv);
        }
    }
}