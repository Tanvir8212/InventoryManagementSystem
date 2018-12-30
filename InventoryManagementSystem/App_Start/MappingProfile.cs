using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Dtos;

namespace InventoryManagementSystem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<ProductType, ProductTypeDto>();
            Mapper.CreateMap<ProductTypeDto, ProductType>();
        }
    }
}