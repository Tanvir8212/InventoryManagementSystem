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
       
        public ActionResult Index()
        {

            return RedirectToAction("ShowProducts", "Product");
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a inventory management system";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Tanvir Mahmud Khan";

            return View();
        }

       


    }
}