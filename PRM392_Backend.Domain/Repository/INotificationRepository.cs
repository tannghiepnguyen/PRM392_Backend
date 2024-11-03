using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetNotifications(string accountID, bool trackChange);
        Task<Notification?> GetNotificationById(Guid id, bool trackChange);
        void CreateNotification(Notification notification);
        void UpdateNotification(Notification notification);
    }
}
