using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface IChatMessageRepository
    {
        void CreateChatMessage(ChatMessage chatMessage);
        Task<IEnumerable<ChatMessage>> GetChatMessages(bool trackChange);
        Task<ChatMessage?> GetChatMessageById(Guid id, bool trackChange);
        void UpdateChatMessage(ChatMessage chatMessage);
        void DeleteChatMessage(Guid id, bool trackChange);
        void HardDeleteChatMessage(Guid id, bool trackChange);
    }
}
