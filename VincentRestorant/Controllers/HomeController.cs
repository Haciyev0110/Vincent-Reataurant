using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;




namespace VincentRestorant.Controllers
{
    public class HomeController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();
        // GET: Home
        public ActionResult Index()
        {
            HomeIndexVM mnv = new HomeIndexVM();
            mnv.mainslider = db.Sliderfirsts.ToList();
            mnv.information = db.Information.ToList();
            mnv.categories = db.Categories.ToList();
            mnv.product = db.Products.ToList();
            User user = Session["user"] as User;
            User userr= Session["user2"] as User;




            return View(mnv);

        }
    }
}