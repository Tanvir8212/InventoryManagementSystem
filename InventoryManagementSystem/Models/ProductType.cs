using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class ProductType
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="Product Type")]
        public string Name { get; set; }
    }
}