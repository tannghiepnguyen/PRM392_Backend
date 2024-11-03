using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.Categories;
using PRM392_Backend.Service.Categories.DTO;
using PRM392_Backend.Service.Notifications.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public NotificationService(IRepositoryManager repositoryManager, UserManager<User> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            this.userManager = userManager; 
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<NotificationResponse>> GetAllNotifications(bool trackChange)
        {
            var userId = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var notifications = await repositoryManager.NotificationRepository.GetNotifications(userId, trackChange);
            return mapper.Map<IEnumerable<NotificationResponse>>(notifications);
        }

        
        public async Task<IEnumerable<NotificationResponse>> CreateNotifications(NotificationRequest request)
        {
            var users = await userManager.GetUsersInRoleAsync(Roles.Customer);
            var notifications = new List<Notification>();
            foreach (var user in users)
            {
                var notification = new Notification
                {
                    ID = Guid.NewGuid(),
                    UserID = user.Id, 
                    Message = request.Message,
                    IsActive = true,
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };            
                notifications.Add(notification);
                repositoryManager.NotificationRepository.CreateNotification(notification);
                await repositoryManager.Save();
            }

            return mapper.Map<IEnumerable<NotificationResponse>>(notifications);
        }

       
        public async Task UpdateNotification(Guid id, bool trackChange)
        {
            var notification = await repositoryManager.NotificationRepository.GetNotificationById(id, trackChange);
            if (notification == null) throw new NotificationNotFoundException("Notification not found!");

            if (!notification.IsRead) 
            {
                notification.IsRead = true;
                repositoryManager.NotificationRepository.UpdateNotification(notification);
                await repositoryManager.Save();
            }
        }
    }
}
