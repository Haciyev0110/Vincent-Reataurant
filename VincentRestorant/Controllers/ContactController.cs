using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Extino;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;


namespace VincentRestorant.Controllers
{
    public class ContactController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();
        // GET: Contact
        public ActionResult Index()
        {
            Contacts bnm = new Contacts();
            bnm.adres = db.Adres_First.ToList();
            bnm.categories = db.Categories.ToList();
            if (db.Products.Count() > 2)
            {
                bnm.prop = db.Products.Where(w => w.Categories_ID == 5).OrderBy(w => w.ID).Skip(4).Take(2).ToList();
            }
            else
            {
                bnm.prop = db.Products.ToList();
            }
            return View(bnm);
        }
    }
}