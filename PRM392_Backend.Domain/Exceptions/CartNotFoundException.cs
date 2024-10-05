using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Exceptions
{
    public class CartNotFoundException : NotFoundException
    {
        public CartNotFoundException(Guid cartId) : base($"The category with id: {cartId} doesn't exist in the database")
        {
        }
    }
}
