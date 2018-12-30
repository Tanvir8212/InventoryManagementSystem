using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext dbContext;

        public ItemController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult ConfirmItemList()
        {
            var itemList = (List<Item>)Session["cart"];

            if(itemList == null)
            {
                return HttpNotFound("You have nothing in cart... How the hell are you here ?????");
            }
            else
            {
                Transaction transaction = new Transaction();
                //transaction.itemIds = itemList;
                transaction.dateTime = DateTime.Now;


                double totalPrice = 0;
                foreach(Item i in itemList)
                {
                    totalPrice = totalPrice + (i.product.sellingPrice * i.quantity);

                    // After confirming updating the quantity of the inventory
                    var product = dbContext.products.SingleOrDefault(p => p.id == i.product.id);
                    if (product.quantity > 0)
                    {
                        product.quantity = product.quantity - i.quantity;
                    }
                    
                }

                transaction.totalPrice = totalPrice;

                dbContext.transactions.Add(transaction);
                dbContext.SaveChanges();
                
            }
            Transaction tran = dbContext.transactions.ToList().Last();
            Session["cart"] = new List<Item>();  // Clearing the session after confirm

            return RedirectToAction("ShowTransaction","Transaction",tran);
        }

        public ActionResult ResetCart()
        {
            Session["cart"] = new List<Item>();
            return RedirectToAction("Index", "Home");
        }
    }
}