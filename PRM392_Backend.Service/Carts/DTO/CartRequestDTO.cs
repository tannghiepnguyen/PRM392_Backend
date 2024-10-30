using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Carts.DTO
{
    public class CartItemRequestDTO
    {
        [Required(ErrorMessage = "ProductID is required")]
        public Guid ProductID { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
    public class CartRequestDTO
    {
      
        public List<CartItemRequestDTO> Items { get; set; }
    }
}
