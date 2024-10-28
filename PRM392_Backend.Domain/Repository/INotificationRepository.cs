using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface INotificationRepository
    {
        Task<Notification> GetNotificationById(Guid id);
        Task<IEnumerable<Notification>> GetAllNotifications();
        void CreateNotification(Notification notification);
        void DeleteNotification(Notification notification);
        Task SaveAsync();
    }
} 