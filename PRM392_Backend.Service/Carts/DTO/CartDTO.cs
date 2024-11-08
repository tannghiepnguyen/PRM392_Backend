using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Carts.DTO
{
    public class CartDTO
    {
        public Guid ID { get; set; }        
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public List<CartItemDTO> CartItems { get; set; }
    }

    public class CartItemDTO
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string StoreID { get; set; }
    }

    public class GetCartItemResponse
    {
        public Guid ID { get; set; }
        public Guid CartID { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
