using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.ChatHubs;
using PRM392_Backend.Service.ChatMessages;
using PRM392_Backend.Service.ChatMessages.DTO;
using PRM392_Backend.Service.IService;

namespace PRM392_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessagesController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatMessagesController(IHubContext<ChatHub> hubContext, IServiceManager serviceManager)
        {
            _hubContext = hubContext;
            this.serviceManager = serviceManager;
        }

        // GET: api/ChatMessages
        [HttpGet]
        public async Task<IActionResult> GetAllChatMessages()
        {
            var chatMessages = await serviceManager.ChatMessageService.GetAllChatMessagesAsync(true);
            return Ok(chatMessages);
        }

        // GET: api/ChatMessages/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatMessageById(Guid id)
        {
            var chatMessage = await serviceManager.ChatMessageService.GetChatMessageByIdAsync(id, true);
            if (chatMessage == null)
            {
                return NotFound();
            }
            return Ok(chatMessage);
        }

        // POST: api/ChatMessages
        [HttpPost]
        public async Task<IActionResult> CreateChatMessage([FromBody] ChatMessageDTORequest chatMessageCreateRequest)
        {
            await serviceManager.ChatMessageService.CreateChatMessageAsync(chatMessageCreateRequest);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", chatMessageCreateRequest.UserID, chatMessageCreateRequest.Message, DateTime.Now);

            // Trả về HTTP OK khi thành công
            return Ok();
        }

        // PUT: api/ChatMessages/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChatMessage(Guid id, [FromBody] ChatMessage chatMessage)
        {
            if (id != chatMessage.ID)
            {
                return BadRequest();
            }

            await serviceManager.ChatMessageService.UpdateChatMessageAsync(chatMessage);
            return NoContent();
        }

        // DELETE: api/ChatMessages/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatMessage(Guid id, [FromQuery] bool trackChange = false)
        {
            await serviceManager.ChatMessageService.DeleteChatMessageAsync(id, trackChange);
            return NoContent();
        }

        // DELETE: api/ChatMessages/hardDelete/{id}
        [HttpDelete("hardDelete/{id}")]
        public async Task<IActionResult> HardDeleteChatMessage(Guid id, [FromQuery] bool trackChange = false)
        {
            await serviceManager.ChatMessageService.HardDeleteChatMessageAsync(id, trackChange);
            return NoContent();
        }
    }
}
