using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class CustomerType
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public int discountRate { get; set; }
    }
}