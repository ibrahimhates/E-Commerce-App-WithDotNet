using AutoMapper;
using Entity.Dtos.CategoryDtos;
using Entity.Dtos.ProductDtos;
using Entity.Models;

namespace Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ProductInsertionDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDetailDto>();
        }
    }
}
