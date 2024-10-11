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
        }
    }
}
