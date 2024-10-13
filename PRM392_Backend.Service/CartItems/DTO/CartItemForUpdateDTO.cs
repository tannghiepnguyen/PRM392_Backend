using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.CartItems.DTO
{
    public class CartItemForUpdateDTO
    {
        public Guid ID { get; set; }
        public int Quantity { get; set; }
        public Guid UserID { get; set; }
    }
}
