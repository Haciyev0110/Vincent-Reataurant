using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class AccountUserController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();
        
        public static User current_user;
        public static int user_id;
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User users)
        {
            if (db.Users.Count(u => u.Username == users.Username) == 1 || db.Users.Count(u => u.Email == users.Email) == 1)
            {
                ModelState.AddModelError("SameUser", "We already have a user with such username or email in our database.");
            }
            else
            {
                users.Password = Crypto.HashPassword(users.Password);
                User    userr= db.Users.Add(users);
                current_user = userr;

                db.SaveChanges();
                Session["user2"] = userr;
                Session["loguser"] = true;
                return RedirectToAction("Index", "Cart");
            }

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (db.Users.Count(u => u.Username == user.Username) == 1)
            {

                if (Crypto.VerifyHashedPassword(db.Users.First(u => u.Username == user.Username).Password, user.Password))
                {
                    current_user = db.Users.First(u => u.Username == user.Username);
                    Session["userLogged"] = true;
                    Session["user"] = db.Users.First(u => u.Username == user.Username) ;
                              List<BasketProduct> basket = Session["basket"] as List<BasketProduct>;

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("Loginerror", "Username  or  password is wrong");
                }

            }
            else
            {
                ModelState.AddModelError("Loginerror", "Username  or  password is wrong");

            }

            return View(user);

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Users()
        {
            HomeIndexVM vm = new HomeIndexVM();
            vm.users = db.Users.ToList();
            return View(vm);
        }

    

    }
}