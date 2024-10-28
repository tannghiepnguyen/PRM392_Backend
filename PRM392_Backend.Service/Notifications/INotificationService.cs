using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Notifications
{
    public interface INotificationService
    {
        Task<Notification> GetNotificationById(Guid id);
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task CreateNotification(Notification notification);
        Task DeleteNotification(Guid id);
        Task UpdateIsRead(Guid id, bool isRead);
    }
} 