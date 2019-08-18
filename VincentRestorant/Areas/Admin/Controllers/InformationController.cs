using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.Extino;


namespace VincentRestorant.Areas.Admin.Controllers
{
    public class InformationController : Controller
    {
        private VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Admin/Information
        public ActionResult Index()
        {
            return View(db.Information.ToList());
        }

        // GET: Admin/Information/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return  RedirectToAction("Index","Information");
            }
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // GET: Admin/Information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Information/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind (Exclude = "Img")] Information information,HttpPostedFileBase Img)
        {
            if (Extension.CheckImg(Img, Extension.MAxfileSize))
            {
                try
                {
                    information.Icon_img = Extension.SaveImg(Img, "~/assets/images/icons");
                  
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
                db.Information.Add(information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(information);
        }

        // GET: Admin/Information/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Information");

            }
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            return View(information);
        }

        // POST: Admin/Information/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Icon_img,Titlecontent,Informationcontent,Img")] Information information,HttpPostedFileBase Img)
        {
            if (Img != null)
            {

                if (Extension.CheckImg(Img, Extension.MAxfileSize))
                {
                    string filename;
                    try
                    {
                        filename = Extension.SaveImg(Img, "~/assets/images/icons");

                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("Img", "Dont correct");
                        return RedirectToAction("Index");
                    }

                    Extension.Deletimg("~/assets/images", information.Icon_img);

                    information.Icon_img = filename;
                }
                else
                {
                    ModelState.AddModelError("Img", "Dont correct");
                    return RedirectToAction("Index");
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(information);
        }

        // GET: Admin/Information/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Information");

            }
            Information information = db.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
          
            return View(information);
        }

        // POST: Admin/Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Dont correct");

            }
            Information information = db.Information.Find(id);
            try
            {
                Extension.Deletimg("~/assets/images/icons", information.Icon_img);
            }
            catch
            {

                return RedirectToAction("index");
            }
            db.Information.Remove(information);
            db.SaveChanges();
            return RedirectToAction("Index");
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
