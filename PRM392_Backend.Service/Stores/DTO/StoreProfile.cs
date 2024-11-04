using AutoMapper;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Stores.DTO
{
    public class StoreProfile : Profile
    {

        public StoreProfile()
        {
            CreateMap<Store, StoreResponse>().ReverseMap();
            CreateMap<Store, GetProductByStoreIdResponse>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ReverseMap();
            CreateMap<Product, ProductResponse>()              
                .ReverseMap();
        }
    }
}

