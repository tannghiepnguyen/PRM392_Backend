using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Exceptions
{
    public class CartItemNotFoundException : NotFoundException
    {
        public CartItemNotFoundException(Guid cartId) : base($"The cart item with id: {cartId} doesn't exist in the database")
        {
        }
    }
}
