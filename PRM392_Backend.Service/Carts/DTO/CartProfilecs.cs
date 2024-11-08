using AutoMapper;
using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Carts.DTO
{
    public class CartProfilecs : Profile
    {
        public CartProfilecs() {
            CreateMap<CartItemRequestDTO?,CartItem>().ReverseMap();

            CreateMap<Cart, CartDTO>()
            .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems));
            CreateMap<CartItem, CartItemDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                 .ForMember(dest => dest.StoreID, opt => opt.MapFrom(src => src.Product.Store.ID))
                .ReverseMap();
            CreateMap<CartItem, GetCartItemResponse>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))            
                .ReverseMap();
        }
    }
}
