using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Areas.Admin.Controllers
{
    public class adminController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Admin/admin
        public ActionResult Index()
        {
            return View();
        }
    }
}