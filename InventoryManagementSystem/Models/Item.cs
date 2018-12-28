using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Item
    {
        public Product product { get; set; }
        public int quantity { get; set; }

        public Item(Product p, int q)
        {
            this.product = p;
            this.quantity = q;
        }

    }
}