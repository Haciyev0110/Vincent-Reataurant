using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class ThpgorapyController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Thpgorapy
        public ActionResult Index()
        {
            HomeIndexVM bnm = new HomeIndexVM();
            bnm.categories = db.Categories.ToList();
            if (db.Products.Count() > 2)
            {
                bnm.prop = db.Products.Where(w => w.Categories_ID == 5).OrderBy(s => s.ID).Skip(4).Take(2).ToList();
            }
            else
            {
                bnm.prop = db.Products.ToList();
            }

            return View(bnm);
        }
    }
}