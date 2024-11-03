using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Infrastructure.Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Notification>> GetNotifications(string accountID, bool trackChange) 
            => await FindByCondition(x => x.UserID == accountID, trackChange).ToListAsync();
        public async Task<Notification?> GetNotificationById(Guid id, bool trackChange) => await FindByCondition(x => x.ID == id, trackChange).SingleOrDefaultAsync();
        public void CreateNotification(Notification notification) => Create(notification);
        public void UpdateNotification(Notification notification) => Update(notification);
    }
}
