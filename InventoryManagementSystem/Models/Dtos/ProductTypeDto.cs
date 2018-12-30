using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models.Dtos
{
    public class ProductTypeDto
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }
}