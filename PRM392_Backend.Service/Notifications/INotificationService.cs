using PRM392_Backend.Domain.PagedList;
using PRM392_Backend.Domain.Parameters;
using PRM392_Backend.Service.Categories.DTO;
using PRM392_Backend.Service.Notifications.DTO;
using PRM392_Backend.Service.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Notifications
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationResponse>> CreateNotifications(NotificationRequest request);
        Task UpdateNotification(Guid id, bool trackChange);
        Task<IEnumerable<NotificationResponse>> GetAllNotifications(bool trackChange);
    }
}
