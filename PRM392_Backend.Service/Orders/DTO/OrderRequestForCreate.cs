using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Orders.DTO
{
    public class OrderRequestForCreate
    {

        public Guid CartID { get; set; }
        public string UserID { get; set; }
        public Guid StoreLocationID { get; set; }
     
        public PaymentMethod PaymentMethod { get; set; }
        
    }
  
}
