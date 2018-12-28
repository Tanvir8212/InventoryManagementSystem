using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Supplier
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Name")]
        public string name { get; set; }

        [Display(Name ="Address")]
        public string address { get; set; }

        [Display(Name ="Phone")]
        public string phone { get; set; }

        [EmailAddress]
        [Display(Name ="Email")]
        public string email { get; set; }

        public List<Product> products { get; set; }

    }
}