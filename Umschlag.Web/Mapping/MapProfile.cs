using AutoMapper;
using Umschlag.Web.DTOs;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Models;

namespace Umschlag.Web.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();
            
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();

            CreateMap<PersonDto, Person>();
            CreateMap<Person, PersonDto>();
        }
    }
}
