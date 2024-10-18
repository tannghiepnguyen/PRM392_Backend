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
    public class ChatMessageRepository : RepositoryBase<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(DatabaseContext context) : base(context)
        {
        }

        /// <summary>
        /// Tạo một tin nhắn mới.
        /// </summary>
        /// <param name="chatMessage">Đối tượng tin nhắn cần tạo.</param>
        public void CreateChatMessage(ChatMessage chatMessage) => Create(chatMessage);

        /// <summary>
        /// Lấy tất cả các tin nhắn.
        /// </summary>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các tin nhắn.</returns>
        public async Task<IEnumerable<ChatMessage>> GetChatMessages(bool trackChange) =>
            await FindAll(trackChange).Include(chatMessage => chatMessage.User).ToListAsync();

        /// <summary>
        /// Lấy tin nhắn theo ID.
        /// </summary>
        /// <param name="id">ID của tin nhắn.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Đối tượng tin nhắn hoặc null nếu không tìm thấy.</returns>
        public async Task<ChatMessage?> GetChatMessageById(Guid id, bool trackChange) =>
            await FindByCondition(x => x.ID == id, trackChange).Include(chatMessage => chatMessage.User).SingleOrDefaultAsync();

        /// <summary>
        /// Cập nhật thông tin tin nhắn.
        /// </summary>
        /// <param name="chatMessage">Đối tượng tin nhắn cần cập nhật.</param>
        public void UpdateChatMessage(ChatMessage chatMessage) => Update(chatMessage);

        /// <summary>
        /// Xóa (soft delete) tin nhắn theo ID.
        /// </summary>
        /// <param name="id">ID của tin nhắn cần xóa.</param>
        public void DeleteChatMessage(Guid id, bool trackChange)
        {
            var chatMessage = FindByCondition(x => x.ID == id, trackChange).SingleOrDefault();
            if (chatMessage != null)
            {
                chatMessage.IsActive = false; // Thực hiện soft delete
                Update(chatMessage);
            }
        }

        /// <summary>
        /// Xóa vĩnh viễn tin nhắn theo ID.
        /// </summary>
        /// <param name="id">ID của tin nhắn cần xóa.</param>
        public void HardDeleteChatMessage(Guid id, bool trackChange)
        {
            var chatMessage = FindByCondition(x => x.ID == id, trackChange).SingleOrDefault();
            if (chatMessage != null)
            {
                Delete(chatMessage); // Sử dụng phương thức Delete từ RepositoryBase để xóa thật sự
            }
        }
    }
}
