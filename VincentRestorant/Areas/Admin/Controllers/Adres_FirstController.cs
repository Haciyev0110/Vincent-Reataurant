using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Extino;
using VincentRestorant.Models;

namespace VincentRestorant.Areas.Admin.Controllers
{
    public class Adres_FirstController : Controller
    {
        private VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Admin/Adres_First
        public ActionResult Index()
        {
            return View(db.Adres_First.ToList());
        }

        // GET: Admin/Adres_First/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index","Adres_First");
            }
            Adres_First adres_First = db.Adres_First.Find(id);
            if (adres_First == null)
            {
                return HttpNotFound();
            }
            return View(adres_First);
        }

        // GET: Admin/Adres_First/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Adres_First/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Img")] Adres_First adres_First, HttpPostedFileBase Img)
        {
            
                if (Extension.CheckImg(Img, Extension.MAxfileSize))
                {
                    try
                    {
                        adres_First.Img = Extension.SaveImg(Img, "~/assets/images/img");

                    }
                    catch
                    {

                        ModelState.AddModelError("Img", "Img is not correct");
                    }
                }
                else
                {
                    ModelState.AddModelError("Img", "Img is not correct");
                }
            
            

            if (ModelState.IsValid)
            {
                db.Adres_First.Add(adres_First);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adres_First);
        }

        // GET: Admin/Adres_First/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Adres_First");

            }
            Adres_First adres_First = db.Adres_First.Find(id);
            if (adres_First == null)
            {
                return HttpNotFound();
            }
            return View(adres_First);
        }

        // POST: Admin/Adres_First/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Img,Adres,WorkingHouse,WorkingTime")] Adres_First adres_First,HttpPostedFileBase  Img)
        {

            if (Img != null)
            {

                if (Extension.CheckImg(Img, Extension.MAxfileSize))
                {
                    string filename;
                    try
                    {
                        filename = Extension.SaveImg(Img, "~/assets/images/img");

                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("Img", "Dont correct");
                        return RedirectToAction("Index");
                    }

                    Extension.Deletimg("~/assets/images", adres_First.Img);

                    adres_First.Img = filename;
                }
                else
                {
                    ModelState.AddModelError("Img", "Dont correct");
                    return RedirectToAction("Index");
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(adres_First).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adres_First);
        }

        // GET: Admin/Adres_First/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Adres_First");


            }
            Adres_First adres_First = db.Adres_First.Find(id);
            if (adres_First == null)
            {
                return HttpNotFound();
            }
            return View(adres_First);
        }

        // POST: Admin/Adres_First/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id != null)
            {
                Adres_First adres_First = db.Adres_First.Find(id);
                try
                {

                    Extension.Deletimg("~/assets/images/icons", adres_First.Img);
                }
                catch
                {

                    return RedirectToAction("index");
                }
                db.Adres_First.Remove(adres_First);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
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
