using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.ChatMessages.DTO
{
    public class ChatMessageDTORequest
    {
        public Guid UserID { get; set; }
        public string Message { get; set; }
        //public DateTime SentdAt { get; set; }
    }
}
