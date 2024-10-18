using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Exceptions
{
    public class ChatMessageNotFoundException : NotFoundException
    {
        public ChatMessageNotFoundException(Guid chartId) : base($"The chat with id: {chartId} doesn't exist in the database")
        {
        }
    }
}
