using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRM392_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public NotificationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification(Guid id)
        {
            var notification = await _serviceManager.NotificationService.GetNotificationById(id);
            if (notification == null)
            {
                return NotFound("Notification not found.");
            }
            return Ok(notification);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _serviceManager.NotificationService.GetAllNotifications();
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] Notification notification)
        {
            if (notification == null)
            {
                return BadRequest("Invalid notification.");
            }
            await _serviceManager.NotificationService.CreateNotification(notification);
            return CreatedAtAction(nameof(GetNotification), new { id = notification.NotificationID }, notification);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(Guid id)
        {
            await _serviceManager.NotificationService.DeleteNotification(id);
            return NoContent();
        }

        [HttpPut("UpdateIsRead/{id}")]
        public async Task<IActionResult> UpdateIsRead(Guid id, [FromBody] bool isRead)
        {
            await _serviceManager.NotificationService.UpdateIsRead(id, isRead);
            return NoContent();
        }
    }
} 