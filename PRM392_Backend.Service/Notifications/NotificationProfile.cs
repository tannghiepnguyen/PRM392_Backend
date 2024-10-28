using AutoMapper;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Service.Notifications
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap();
        }
    }
} 