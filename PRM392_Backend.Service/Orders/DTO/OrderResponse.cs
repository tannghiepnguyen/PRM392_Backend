using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Carts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Orders.DTO
{
    public class OrderResponse
    {
        public Guid ID { get; set; }
        public string BillingAddress { get; set; }
        public CartDTO Cart { get; set; }
        public UserResponse User { get; set; }
        public StoreLocationResponse StoreLocation { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderStatus { get; set; }
    }

    public class UserResponse
    {
        public Guid ID { get; set; }
        public string FullName { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
    }

    public class StoreLocationResponse
    {
        public Guid ID { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
