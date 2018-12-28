using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name ="Product Name")]
        public string name { get; set; }

        [Display(Name = "Selling Price")]
        public double sellingPrice { get; set; }

        [Display(Name = "Product Type")]
        public ProductType productType { get; set; }

        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Display(Name = "Supplier")]
        public Supplier supplier { get; set; }


    }
}