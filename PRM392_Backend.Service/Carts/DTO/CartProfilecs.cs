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
        }
    }
}
