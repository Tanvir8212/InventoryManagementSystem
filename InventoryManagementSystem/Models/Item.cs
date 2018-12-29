using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; }

       
        public Product product { get; set; }
        public int quantity { get; set; }

       /* public Item(Product p, int q)
        {
            this.product = p;
            this.quantity = q;
        }*/

    }
}