using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class CartController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Cart
        public ActionResult Index()
        {

            List<BasketProduct> basket = new List<BasketProduct>();
            basket = Session["basket"] as List<BasketProduct>;
            User user = Session["user"] as User;
            ViewBag.pro = db.Categories.ToList();
            return View(basket);
        }
    }
}