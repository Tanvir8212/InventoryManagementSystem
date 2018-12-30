using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models.Dtos
{
    public class ProductDto
    {

        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public double sellingPrice { get; set; }

        public ProductTypeDto productType { get; set; }

        public int quantity { get; set; }

        public Supplier supplier { get; set; }

    }
}