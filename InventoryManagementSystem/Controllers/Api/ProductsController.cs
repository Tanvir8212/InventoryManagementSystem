using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext dbContext;
        public ProductsController()
        {
            dbContext = new ApplicationDbContext();
        }

        // get/  api/products

        public IEnumerable<Product> GetProducts()
        {
           return dbContext.products.ToList();
        }
    }
}
