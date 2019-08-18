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
    public class Second_SliderController : Controller
    {
        private VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Admin/Second_Slider
        public ActionResult Index()
        {
            return View(db.Second_Slider.ToList());
        }

        // GET: Admin/Second_Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Second_Slider second_Slider = db.Second_Slider.Find(id);
            if (second_Slider == null)
            {
                return HttpNotFound();
            }
            return View(second_Slider);
        }

        // GET: Admin/Second_Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Second_Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Img")] Second_Slider second_Slider,HttpPostedFileBase  Img)
        {
            if (Img != null)
            {
                if (Extension.CheckImg(Img, Extension.MAxfileSize))
                {
                    try
                    {
                        second_Slider.Img = Extension.SaveImg(Img, "~/assets/images/img");

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
            }
            else
            {

            }
          
            if (ModelState.IsValid)
            {
                db.Second_Slider.Add(second_Slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(second_Slider);
        }

        // GET: Admin/Second_Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Second_Slider second_Slider = db.Second_Slider.Find(id);
            if (second_Slider == null)
            {
                return HttpNotFound();
            }
            return View(second_Slider);
        }

        // POST: Admin/Second_Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Img")] Second_Slider second_Slider,HttpPostedFileBase  Img)
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

                    Extension.Deletimg("~/assets/images", second_Slider.Img);

                    second_Slider.Img = filename;
                }
                else
                {
                    ModelState.AddModelError("Img", "Dont correct");
                    return RedirectToAction("Index");
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(second_Slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(second_Slider);
        }

        // GET: Admin/Second_Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Second_Slider second_Slider = db.Second_Slider.Find(id);
            if (second_Slider == null)
            {
                return HttpNotFound();
            }
            return View(second_Slider);
        }

        // POST: Admin/Second_Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {

            }
            Second_Slider second_Slider = db.Second_Slider.Find(id);

            try
            {
                Extension.Deletimg("~/assets/images/icons",second_Slider.Img);
            }
            catch
            {

                return RedirectToAction("index");
            }

            db.Second_Slider.Remove(second_Slider);
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
