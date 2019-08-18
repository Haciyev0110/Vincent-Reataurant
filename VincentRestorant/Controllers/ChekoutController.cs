using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class ChekoutController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Chekout
        public ActionResult Index()
        {
            User user = Session["user"] as User;
            User users = Session["user2"] as User;

            List<BasketProduct> basket = Session["basket"] as List<BasketProduct>;
            Order orderss = new Order();



            if (user !=null || users != null)
            {

                if (user == null)
                {
                    orderss.Users_ID = users.ID;
                }
                else
                {
                    orderss.Users_ID = user.ID;
                }
                orderss.Date = DateTime.Now;
                orderss.Status = false;
                   
                db.Orders.Add(orderss);
                db.SaveChanges();

                foreach (var item in basket)
                {
                    Ordersitem itemoder = new Ordersitem();
                    itemoder.Orders_ID = orderss.ID;
                    itemoder.Count = item.Count;
                    itemoder.Orderprice = item.Subtotal;
                    itemoder.Productsize_Id = item.ProductsizId;

                   
                    db.Ordersitems.Add(itemoder);
                    db.SaveChanges();
                }
            }
            else
            {
                return RedirectToAction("Register", "AccountUser");


            }
            Session.Remove("basket");

            return View();
        }
    }
}