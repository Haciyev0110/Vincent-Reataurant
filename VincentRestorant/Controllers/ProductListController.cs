using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;



namespace VincentRestorant.Controllers
{
    public class ProductListController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();
        // GET: ProductList
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int skip = ((int)page - 1) * 4;
            HomeIndexVM bnm = new HomeIndexVM
            {
                product = db.Products.OrderBy(w=>w.ID).Skip(skip).Take(8).ToList()
            };
            ViewBag.TotalPage = Math.Ceiling(db.Products.Count() / 4.0);
            ViewBag.Page = page;
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