using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Transaction
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Item")]
        public List<int> itemIds { get; set; }
        public double totalPrice { get; set; }
        public double profit { get; set; }
        public Customer customer { get; set; }
        public DateTime dateTime { get; set; }
    }
}