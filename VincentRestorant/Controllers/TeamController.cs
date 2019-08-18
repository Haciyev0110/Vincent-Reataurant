using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class TeamController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Team
        public ActionResult Index()
        {
            AAbout bnm = new AAbout();
            bnm.teams = db.Teams.ToList();
            return View(bnm);
        }
    }
}