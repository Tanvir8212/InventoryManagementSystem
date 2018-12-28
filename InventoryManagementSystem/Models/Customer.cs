using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Customer Name")]
        public string name { get; set; }

        [Display(Name ="Customer Type")]
        public CustomerType customerType { get; set; }

        [Display(Name ="Total Purchase")]
        public int totalPurchase { get; set; }

        [EmailAddress]
        [Display(Name ="Email")]
        public string email { get; set; }










    }
}