using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext dbContext;

        public AdminController()
        {
            dbContext = new ApplicationDbContext();
        }


        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.transactions = dbContext.transactions.ToList();
            

            return View(adminViewModel);
        }
    }
}