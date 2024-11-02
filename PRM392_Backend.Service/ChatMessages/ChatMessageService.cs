using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.ChatHubs;
using PRM392_Backend.Service.ChatMessages.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.ChatMessages
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatMessageService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHubContext<ChatHub> hubContext)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _hubContext = hubContext;   
        }

        public async Task<IEnumerable<ChatMessage>> GetAllChatMessagesAsync(bool trackChange = false)
        {
            return await _repositoryManager.ChatMessageRepository.GetChatMessages(trackChange);
        }

        public async Task<ChatMessage?> GetChatMessageByIdAsync(Guid id, bool trackChange = false)
        {
            return await _repositoryManager.ChatMessageRepository.GetChatMessageById(id, trackChange);
        }

        public async Task CreateChatMessageAsync(ChatMessageDTORequest chatMessageCreateRequest)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            ChatMessage chatMessage = new ChatMessage
            {
                UserID = userId,
                Message = chatMessageCreateRequest.Message,
                SentdAt = DateTime.Now,
                IsActive = true
            };

            _repositoryManager.ChatMessageRepository.CreateChatMessage(chatMessage);
            await _repositoryManager.Save();

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", userId, chatMessage.Message, chatMessage.SentdAt);
        }

        public async Task UpdateChatMessageAsync(ChatMessage chatMessage)
        {
            _repositoryManager.ChatMessageRepository.UpdateChatMessage(chatMessage);
            await _repositoryManager.Save();
        }

        public async Task DeleteChatMessageAsync(Guid id, bool trackChange = false)
        {
            _repositoryManager.ChatMessageRepository.DeleteChatMessage(id, trackChange);
            await _repositoryManager.Save();
        }

        public async Task HardDeleteChatMessageAsync(Guid id, bool trackChange = false)
        {
            _repositoryManager.ChatMessageRepository.HardDeleteChatMessage(id, trackChange);
            await _repositoryManager.Save();
        }
    }
}
