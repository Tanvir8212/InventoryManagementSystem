using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InventoryManagementSystem.Models;
using System.Data.Entity;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext dbContext;

        public ProductController()
        {
            dbContext = new ApplicationDbContext();
        }

        // GET: Product
        public ActionResult Index()
        {

            return RedirectToAction("ShowProducts", "Product");
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

            // return View("ShowProducts", "Product", product);
            Item item = new Item();
            if (product != null)
            {
                int quantity = 1;

                var itemList = (List<Item>)Session["cart"];
                foreach (var i in itemList)
                {
                    if (i.product.id == product.id)
                    {
                        i.quantity++;
                        quantity++;
                    }
                }

                if (quantity == 1)
                {
                    
                    item.product = product;
                    item.quantity = quantity;
                    itemList.Add(item);
                }


            }

           // return View(item);
           // return View("Temp", "Product", item);

           return RedirectToAction("ShowItemList", "Product");
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

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ProductTypeList = dbContext.productTypes.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            try
            {
                dbContext.products.Add(product);
                dbContext.SaveChanges();

            }catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            

            return RedirectToAction("Create","Product");
        }

    }
}