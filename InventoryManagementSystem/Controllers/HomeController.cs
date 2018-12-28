using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.Models;
using System.Data.Entity;

namespace InventoryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;

        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            return RedirectToAction("ShowProducts", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowProducts()
        {
            var products = dbContext.products.Include(p => p.productType).ToList();

            var itemList = (List<Item>)Session["cart"];

            if (itemList == null)
            {
                Session["cart"] = new List<Item>();
            }

            return View(products);
        }

        public ActionResult AddToCart(int productID)
        {
            var product = dbContext.products.SingleOrDefault(p => p.id == productID);
            if(product!= null)
            {
                int quantity = 1;
               
                var itemList = (List<Item>)Session["cart"];
                foreach(var i in itemList)
                {
                    if(i.product.id == product.id)
                    {
                        i.quantity++;
                        quantity++;
                    }
                }

                if (quantity == 1)
                {
                    Item item = new Item(product, quantity);
                    itemList.Add(item);
                }

                
            }
            

            return RedirectToAction("ShowItemList", "Home");
        }

        public ActionResult ShowItemList()
        {
            var itemList = (List<Item>)Session["cart"];

            if (itemList == null)
            {
                return new HttpNotFoundResult("You didn't add anything to cart... Why the hell are you here ??");
            }

            return View(itemList);
        }


    }
}