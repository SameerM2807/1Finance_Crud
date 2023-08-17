using _1FinanceAssignment_Web_Api_.AccountDto;
using _1FinanceAssignment_Web_Api_.CategoryDto;
using _1FinanceAssignment_Web_Api_.Models;
using _1FinanceAssignment_Web_Api_.ProductDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _1FinanceAssignment_Web_Api_.Configurations
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<Category,AddCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryDto>().ReverseMap();
            CreateMap<Product,AddProductDto>().ReverseMap();
            CreateMap<Product,GetProductDto>().ReverseMap();
            CreateMap<User,RegisterDto>().ReverseMap();
        }
    }
}
