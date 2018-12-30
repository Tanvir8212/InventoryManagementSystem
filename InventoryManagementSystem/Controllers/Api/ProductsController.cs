using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Dtos;

namespace InventoryManagementSystem.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext dbContext;
        public ProductsController()
        {
            dbContext = new ApplicationDbContext();
        }

        // GET/  api/products

        public IEnumerable<ProductDto> GetProducts()
        {
           return dbContext.products.ToList().Select(Mapper.Map<Product,ProductDto>);
        }

        // GET/  api/products/6
        public ProductDto GetProduct(int id)
        {
            var product = dbContext.products.SingleOrDefault(p => p.id == id);
            return Mapper.Map<Product,ProductDto>(product);
        }

        // GET/ api/products?quantity=low
        public IEnumerable<ProductDto> GetProduct(string quantity)
        {
            var products = dbContext.products.ToList().Select(Mapper.Map<Product, ProductDto>);

            if (quantity == "low")
            {
                products = dbContext.products.Where(p => p.quantity <10).Select(Mapper.Map<Product, ProductDto>);
            }
            
            return products;
        }

        // POST/ api/products
        public ProductDto createProduct(ProductDto productDto)
        {
            var product = Mapper.Map<ProductDto, Product>(productDto);

            dbContext.products.Add(product);
            try
            {
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            productDto.id = product.id;

            return productDto;
        }

        // PUT/ api/products/6
        [HttpPut]
        public void UpdateProduct(int productID,ProductDto updatedProductDto)
        {
            var product = dbContext.products.SingleOrDefault(p => p.id == productID);

            if (product != null)
            {
                Mapper.Map<ProductDto, Product>(updatedProductDto, product);
                dbContext.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            
        }

        // DELETE/ api/products/6
        [HttpDelete]
        public void DeleteProduct(int productID)
        {
            var product = dbContext.products.SingleOrDefault(p => p.id == productID);

            if(product != null)
            {
                dbContext.products.Remove(product);

                dbContext.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
