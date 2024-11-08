using AutoMapper;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Carts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Orders.DTO
{
    public class OrderProfilecs : Profile
    {
        public OrderProfilecs()
        {
            CreateMap<OrderRequestForCreate, Order>().ReverseMap();
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.StoreLocation, opt => opt.MapFrom(src => src.StoreLocation))
                .ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<StoreLocation, StoreLocationResponse>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.StoreName))
                .ReverseMap();
        }
    }
}
