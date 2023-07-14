using AutoMapper;
using Entity.Dtos.AddressDtos;
using Entity.Dtos.CartDtos;
using Entity.Dtos.CategoryDtos;
using Entity.Dtos.OrderDtos;
using Entity.Dtos.ProdcutCartDtos;
using Entity.Dtos.ProdcutOrderDtos;
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

            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderUpdateDto, Order>();

            CreateMap<AddressDto, Address>().ReverseMap();

            CreateMap<CartDto, Cart>().ReverseMap();

            CreateMap<ProductOrderDto, ProductOrder>().ReverseMap();

            CreateMap<ProductCartDto, ProductCart>().ReverseMap();
        }
    }
}
