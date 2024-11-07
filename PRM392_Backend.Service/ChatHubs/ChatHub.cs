using Microsoft.AspNetCore.SignalR;
using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PRM392_Backend.Service.ChatHubs
{
    public class ChatHub : Hub
    {
        private static readonly Dictionary<string, string> userConnections = new();

        public async Task SendMessage(string userId, string message)
        {
            var connectionId = userConnections[userId];
            if (connectionId != null)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", userId, message, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.GetHttpContext().Request.Query["userId"];
            userConnections[userId] = Context.ConnectionId;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.GetHttpContext().Request.Query["userId"];
            userConnections.Remove(userId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
