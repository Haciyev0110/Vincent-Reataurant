using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;
using VincentRestorant.Extino;
using System.Threading.Tasks;

namespace VincentRestorant.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private VincentRestourantEntities db = new VincentRestourantEntities();

        // GET: Admin/Products
        public ActionResult Index()
        {            var products = db.Products.Include(p => p.Category);
             ViewBag.ProductSizes = db.ProductSizes.ToList();


            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index","Products");
            }
            
            Product product = db.Products.Find(id);
                
            List<ProductSize> productSize = db.ProductSizes.Where(t => t.Product.ID == id).ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.Categories_ID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.Sizes = db.Sizes.ToList();
            ViewBag.ProductSize = db.ProductSizes.ToList();

            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "ID,Name,Categories_ID,Mini_text,Big_text,Status,Inkrudent")] Product product, HttpPostedFileBase Img_producr,int[] SizeId,string[] Price)
        {


            if (Extension.CheckImg(Img_producr, Extension.MAxfileSize))
            {
                try
                {
                    product.Img_producr = Extension.SaveImg(Img_producr, "~/assets/Products");

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

                db.Products.Add(product);
                db.SaveChanges();

               




                for (int i = 0; i < SizeId.Length; i++)
                {
                    ProductSize snm = new ProductSize();
                    snm.Size_ID = SizeId[i];
                    snm.Product_ID = product.ID;
                    snm.Price = Convert.ToDecimal(Price[i]);

                    db.ProductSizes.Add(snm);
                    db.SaveChanges();
                }




                return RedirectToAction("Index");


            }

            ViewBag.Categories_ID = new SelectList(db.Categories, "ID", "Name", product.Categories_ID);
            ViewBag.Sizes = db.Sizes.ToList();


            return RedirectToAction("Index");
        }

        // GET: Admin/Products/Edit/5
        public   ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Products");


            }
            Product product = db.Products.Find(id);
            ViewBag.productSize = db.ProductSizes.Where(t => t.Product.ID == id).ToList();
            ViewBag.Sizes = db.Sizes.ToList();

            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories_ID = new SelectList(db.Categories, "ID", "Name", product.Categories_ID);

     
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit([Bind(Include = "ID,Name,Categories_ID,Mini_text,Big_text,Status,Inkrudent")] Product product, HttpPostedFileBase Img, int[] SizeId, string[] price, int[] productSizeID,string fileadi)
        {
            if (Img != null)
            {

                if (Extension.CheckImg(Img, Extension.MAxfileSize))
                {
                    string filename;
                    try
                    {
                        filename = Extension.SaveImg(Img, "~/assets/Products");

                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("Img", "Dont correct");
                        return RedirectToAction("Index");
                    }


                    Extension.Deletimg("~/assets/Products", fileadi);

                    product.Img_producr = filename;
                }
                else
                {
                    ModelState.AddModelError("Img", "Dont correct");
                    return RedirectToAction("Index");
                }
            }
            else
            {
                product.Img_producr = fileadi;
            }
            db.SaveChanges();
           //int  k = product.Inkrudent.Length;
            if (ModelState.IsValid)
            {

                //product.Inkrudent.Trim();
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                for (int i = 0; i < productSizeID.Length; i++)
                {
                    ProductSize editpr = db.ProductSizes.Find(productSizeID[i]);

                    editpr.Size_ID = SizeId[i];
                    editpr.Price = Convert.ToDecimal(price[i]);
                    db.Entry(editpr).State = EntityState.Modified;
                    db.SaveChanges();
                }
               


            }
            return RedirectToAction("Index","Admin/Products/Index");

            //ViewBag.Categories_ID = new SelectList(db.Categories, "ID", "Name", product.Categories_ID);
            //return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Products");

            }
            Product product = db.Products.Find(id);


            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            List<ProductSize> productSize = db.ProductSizes.Where(t => t.Product.ID == id).ToList();



            foreach (var item in productSize)
            {
                ProductSize pnh = db.ProductSizes.Find(item.ID);
                db.ProductSizes.Remove(pnh);
                db.SaveChanges();
            }


            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            if (product == null)
            {
                return HttpNotFound("Dont correct");
            }
            try
            {
                Extension.Deletimg("~/assets/images/icons", product.Img_producr);
            }
            catch
            {

                return RedirectToAction("Index");
            }


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
