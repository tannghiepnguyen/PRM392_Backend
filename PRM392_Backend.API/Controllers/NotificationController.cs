using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Categories.DTO;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Notifications.DTO;

namespace PRM392_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public NotificationController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        [Authorize(Roles = Roles.Customer)]
        public async Task<IActionResult> GetNotification()
        {
            var notifications = await serviceManager.NotificationService.GetAllNotifications(trackChange: false);
            return Ok(notifications);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> CreateNotifications([FromBody] NotificationRequest request)
        {
            var notifications = await serviceManager.NotificationService.CreateNotifications(request);
            return Ok(notifications);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Customer)]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id)
        {
            await serviceManager.NotificationService.UpdateNotification(id, trackChange: false);
            return NoContent();
        }

    }
}
