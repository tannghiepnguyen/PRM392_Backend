using AutoMapper;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Carts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.CartItems.DTO
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile() {
            CreateMap<CartItemForUpdateDTO?, CartItem>().ReverseMap();
        }
    }
}
