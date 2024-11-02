using Microsoft.AspNetCore.SignalR;
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
            
            await Clients.All.SendAsync("ReceiveMessage", userId, message);
        }
    }
}
