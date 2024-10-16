using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Carts.DTO
{
    public class CartItemRequestDTO
    {
  
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
    public class CartRequestDTO
    {
      
        public List<CartItemRequestDTO> Items { get; set; }
    }
}
