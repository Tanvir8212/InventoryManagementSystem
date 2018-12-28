using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class TransactionController : Controller
    {
        
        public ActionResult ShowTransaction(Transaction transaction)
        {

            return View(transaction);
        }
    }
}