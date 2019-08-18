using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VincentRestorant.Models;
using VincentRestorant.ViewModel;

namespace VincentRestorant.Controllers
{
    public class AJAXController : Controller
    {
        VincentRestourantEntities db = new VincentRestourantEntities();

        [HttpPost]
        public ActionResult UptadeProduct(int id, int changeCount)
        {
            List<BasketProduct> basket = Session["basket"] as List<BasketProduct>;

            for (int i = 0; i < basket.Count; i++)
            {

                if (basket[i].ID == id)
                {
                    basket[i].Count = changeCount;
                    break;

                }

            }

            return Json(new
            {
                msg = 200,
                error = "",
                data = basket,
            }, JsonRequestBehavior.AllowGet);




        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {



            List<BasketProduct> basket = new List<BasketProduct>();

            basket = Session["basket"] as List<BasketProduct>;


            BasketProduct selectpro = basket.FirstOrDefault(i => i.ID == id);
            if (basket != null)
            {
                if (selectpro.Count >= 1)
                {

                    basket.Remove(selectpro);
                    Session["basket"] = basket;


                }
            }
            return Json(basket);
        }

        // GET: AJAX
        public ActionResult Addtobasket(int? productId,int?  sizeid)
        {
            if (productId == null)
            {
                return Json(new
                {
                    msg = 401,
                    error = "Id is  not specifed",
                    data = ""
                }, JsonRequestBehavior.AllowGet);
            }

            Product pro = db.Products.Find(productId);
            if (pro == null)
            {
                return HttpNotFound();
            }

            List<BasketProduct> basket = new List<BasketProduct>();
            if (Session["basket"] != null)
            {
                basket = Session["basket"] as List<BasketProduct>;
            }

            BasketProduct selectpro = basket.FirstOrDefault(i => i.ID == productId);

            if (sizeid == null)
            {
                if (pro.Categories_ID == 5)
                {
                    sizeid = 2;

                }
                else
                {
                    sizeid = 1;
                }
            }
            if (selectpro != null)
            {
                selectpro.Count += 1;
                selectpro.Subtotal += (decimal)pro.ProductSizes.FirstOrDefault(p => p.Size_ID == sizeid).Price;
                selectpro.ProductsizId = (int)sizeid;


            }
            else
            {
                
                basket.Add(new BasketProduct
                {

                    ID = pro.ID,
                    Name = pro.Name,
                    Price = (decimal)pro.ProductSizes.FirstOrDefault(p => p.Size_ID == sizeid).Price,
                    Subtotal = (decimal)pro.ProductSizes.First().Price,
                    ProductsizId = pro.ID,
                    Image = pro.Img_producr,
                    size = (int)sizeid,
                    CategoriesId=(int)pro.Categories_ID,
                    Count = 1

                });
            }
            Session["basket"] = basket;




            return Json(new
            {
                msg = 200,
                error = "",
                data = basket
            }, JsonRequestBehavior.AllowGet);

        }

    }
}