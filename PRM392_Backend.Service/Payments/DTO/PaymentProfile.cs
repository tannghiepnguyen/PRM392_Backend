using AutoMapper;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Payments.DTO
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentResponse, Payment>().ReverseMap();       
        }
    }
}
