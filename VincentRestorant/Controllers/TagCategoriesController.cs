using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class TagCategoriesController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();
        // GET: TagCategories
        public ActionResult Index(int? page,int  categ)
        {

            if (page == null)
            {
                page = 1;
            }
            HomeIndexVM bnm = new HomeIndexVM();

            int skip = ((int)page - 1) * 8;

                bnm.product = db.Products.Where(s => s.Categories_ID == categ).OrderBy(p => p.ID).Skip(skip).Take(8).ToList();
            

            ViewBag.TotalPage = Math.Ceiling(db.Products.Where(s=>s.Categories_ID==categ).Count() / 8.0);
            ViewBag.Page = page;
            ViewBag.Cat = db.Categories.Find(categ);

            bnm.categories = db.Categories.ToList();
            if (db.Products.Count() > 2)
            {
                bnm.prop = db.Products.Where(m => m.Categories_ID == 5).OrderBy(w => w.ID).Skip(4).Take(2).ToList();

            }
            else
            {
                bnm.prop = db.Products.ToList();
            }
            return View(bnm);
        }
    }
}