using Microsoft.AspNetCore.SignalR;
using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.ChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userId, string message)
        {
            var chatMessage = new ChatMessage
            {
                UserID = userId,
                Message = message,
                SentdAt = DateTime.Now,
                IsActive = true
            };
            await Clients.All.SendAsync("ReceiveMessage", userId, message, chatMessage.SentdAt);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task NotifyTyping(string userId)
        {
            await Clients.Others.SendAsync("UserTyping", userId);
        }
    }
}
