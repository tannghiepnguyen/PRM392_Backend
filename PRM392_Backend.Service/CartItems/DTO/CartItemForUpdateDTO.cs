using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.CartItems.DTO
{
    public class CartItemForUpdateDTO
    {
        [Required(ErrorMessage = "ID is required.")]
        public Guid ID { get; set; }

        // Quantity must be greater than 0
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

    }
}
