using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.ChatMessages.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.ChatMessages
{
    public interface IChatMessageService
    {
        Task<IEnumerable<ChatMessage>> GetAllChatMessagesAsync(bool trackChange = false);
        Task<ChatMessage?> GetChatMessageByIdAsync(Guid id, bool trackChange = false);
        Task CreateChatMessageAsync(ChatMessageDTORequest chatMessageCreateRequest);
        Task UpdateChatMessageAsync(ChatMessage chatMessage);
        Task DeleteChatMessageAsync(Guid id, bool trackChange = false);
        Task HardDeleteChatMessageAsync(Guid id, bool trackChange = false);
    }
}
