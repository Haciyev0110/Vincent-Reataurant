using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;

namespace VincentRestorant.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private VincentRestourantEntities db = new VincentRestourantEntities();

        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.User);
            return View(orders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            List<Ordersitem> ordelist = new List<Ordersitem>();
            ordelist= db.Ordersitems.Where(w=>w.Orders_ID==order.ID).ToList();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        public  ActionResult  Accept(int? id)
        {
            if (id != null)
            {
                Order order = db.Orders.Find(id);
                order.Status = true;
                db.SaveChanges();
            }
            else
            {
                HttpNotFound("Error");
            }

            return RedirectToAction("Index", "Orders");
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
