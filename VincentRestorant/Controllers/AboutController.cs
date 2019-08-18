using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;


namespace VincentRestorant.Controllers
{
    public class AboutController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();
        // GET: About
        public ActionResult Index()
        {
            AAbout bnm = new AAbout();
            bnm.secon_slider = db.Second_Slider.ToList();
            bnm.information = db.Information.ToList();
            bnm.partners = db.Partners.ToList();
            if (db.Adres_First.Count() >2)
            {
                bnm.adress = db.Adres_First.Take(2).ToList();

            }
            else
            {
                bnm.adress = db.Adres_First.ToList();
            }
            if (db.Teams.Count() > 3)
            {
                bnm.teams = db.Teams.Take(3).ToList();

            }
            else
            {
                bnm.teams = db.Teams.ToList();
            }
            return View(bnm);
        }
    }
}