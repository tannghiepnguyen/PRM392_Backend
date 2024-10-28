using AutoMapper;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PRM392_Backend.Service.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public NotificationService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Notification> GetNotificationById(Guid id) =>
            await _repositoryManager.NotificationRepository.GetNotificationById(id);

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            var notifications = await _repositoryManager.NotificationRepository.GetAllNotifications();
            
            // Ghi log để kiểm tra giá trị
            foreach (var notification in notifications)
            {
                Console.WriteLine($"NotificationID: {notification.NotificationID}, UserID: {notification.UserID}, Message: {notification.Message}, IsRead: {notification.IsRead}, CreatedAt: {notification.CreatedAt}");
            }

            return notifications;
        }

        public async Task CreateNotification(Notification notification)
        {
            try
            {
                // Ghi log giá trị của notification
                Console.WriteLine($"Creating notification: UserID={notification.UserID}, Message={notification.Message}, IsRead={notification.IsRead}, CreatedAt={notification.CreatedAt}");

                _repositoryManager.NotificationRepository.CreateNotification(notification);
                await _repositoryManager.NotificationRepository.SaveAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Log the inner exception for more details
                throw new Exception("Database update error occurred while saving the notification.", dbEx.InnerException);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("An error occurred while saving the notification.", ex);
            }
        }

        public async Task DeleteNotification(Guid id)
        {
            var notification = await GetNotificationById(id);
            if (notification != null)
            {
                _repositoryManager.NotificationRepository.DeleteNotification(notification);
                await _repositoryManager.NotificationRepository.SaveAsync();
            }
        }

        public async Task UpdateIsRead(Guid id, bool isRead)
        {
            var notification = await GetNotificationById(id);
            if (notification != null)
            {
                notification.IsRead = isRead;
                await _repositoryManager.NotificationRepository.SaveAsync();
            }
        }
    }
} 