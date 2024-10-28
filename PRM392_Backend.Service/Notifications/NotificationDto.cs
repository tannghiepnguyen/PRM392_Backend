using System;

namespace PRM392_Backend.Service.Notifications
{
    public class NotificationDto
    {
        public Guid NotificationID { get; set; }
        public string UserID { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 