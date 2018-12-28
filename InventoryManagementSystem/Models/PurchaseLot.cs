using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class PurchaseLot
    {
        [Key]
        public int id { get; set; }

        public Product product { get; set; }
        public double buyingPrice { get; set; }
        public int quantity { get; set; }
        public DateTime dateTime { get; set; }





    }
}