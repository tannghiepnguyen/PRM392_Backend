using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid orderId) : base($"The order with id: {orderId} doesn't exist in the database")
        {
        }

        public OrderNotFoundException(string message) : base(message) { }
    }
}
