using AutoMapper;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Notifications.DTO
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationRequest, Notification>().ReverseMap();
            CreateMap<NotificationResponse, Notification>().ReverseMap();          
        }
    }
}
