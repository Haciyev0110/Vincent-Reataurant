using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.Extino;
using System.Data.Entity;



namespace VincentRestorant.Areas.Admin.Controllers
{
    public class MainsliderController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Admin/Mainslider
        public ActionResult Index()
        {
          var  nm = db.Sliderfirsts.ToList();
            return View(nm);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult   Create([Bind(Exclude ="Img")]Sliderfirst detales,HttpPostedFileBase Img, HttpPostedFileBase Img2)
        {
            if (Extension.CheckImg(Img, Extension.MAxfileSize))
            {
                try
                {
                    detales.Img = Extension.SaveImg(Img, "~/assets/images/slider");
                    if (detales.Img2 != null)
                    {
                        detales.Img2 = Extension.SaveImg(Img2, "~/assets/images/Pizzas");

                    }
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
            if(!ModelState.IsValid)
            {
                return View(detales);
            }
            db.Sliderfirsts.Add(detales);
            db.SaveChanges();

            return RedirectToAction("Index");











        }


        public ActionResult Detales(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Id is not space file");
            }
            Sliderfirst br = db.Sliderfirsts.Find(id);

            if (br == null)
            {
                return HttpNotFound("Id is not space file");
            }

            return View(br);
        }


        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return HttpNotFound("Dont correct");
            }
            Sliderfirst br = db.Sliderfirsts.Find(id);
            if (br == null)
            {
                return HttpNotFound("Dont correct");
            }
            return View(br);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Dont correct");
            }
            Sliderfirst br = db.Sliderfirsts.Find(id);
            if (br == null)
            {
                return HttpNotFound("Dont correct");
            }
            try
            {
                Extension.Deletimg("~/assets/images/slider", br.Img);
            }
            catch
            {

                return RedirectToAction("index");
            }
            db.Sliderfirsts.Remove(br);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Id is not specefed");
            }
            Sliderfirst bd = db.Sliderfirsts.Find(id);
            if (bd == null)
            {
                return HttpNotFound("Dont correct");
            };

            return View(bd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sliderfirst detales, HttpPostedFileBase NewImg, HttpPostedFileBase NewImg2)
        {
            if (NewImg != null)
            {

                if (Extension.CheckImg(NewImg, Extension.MAxfileSize))
                {
                    string filename;
                    try
                    {
                        filename = Extension.SaveImg(NewImg, "~/assets/images/slider");

                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("Img", "Dont correct");
                        return RedirectToAction("Index");
                    }

                    Extension.Deletimg("~/assets/images", detales.Img);

                    detales.Img = filename;
                }
                else
                {
                    ModelState.AddModelError("Img", "Dont correct");
                    return RedirectToAction("Index");
                }
            }
            if (NewImg2 != null)
            {

                if (Extension.CheckImg(NewImg2, Extension.MAxfileSize))
                {
                    string filename2;
                    try
                    {
                        filename2 = Extension.SaveImg(NewImg2, "~/assets/images/Pizzas");

                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("Img", "Dont correct");
                        return RedirectToAction("Index");
                    }
                    if (detales.Img2 != null)
                    {
                        Extension.Deletimg("~/assets/images/", detales.Img2);

                    }

                    detales.Img2 = filename2;
                }
                else
                {
                    ModelState.AddModelError("Img", "Dont correct");
                    return RedirectToAction("Index");
                }
            }

            db.Entry(detales).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }



    }


    

}