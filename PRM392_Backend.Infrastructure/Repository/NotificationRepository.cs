using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRM392_Backend.Infrastructure.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DatabaseContext _context;

        public NotificationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Notification> GetNotificationById(Guid id) =>
            await _context.Notifications.FindAsync(id);

        public async Task<IEnumerable<Notification>> GetAllNotifications() =>
            await _context.Notifications.ToListAsync();

        public void CreateNotification(Notification notification) => _context.Notifications.Add(notification);

        public void DeleteNotification(Notification notification) => _context.Notifications.Remove(notification);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
} 