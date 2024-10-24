﻿using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface ICartRepository
    {
        void CreateCart(Cart cart);
        Task<IEnumerable<Cart>> GetCarts(bool trackChange);
        Task<IEnumerable<Cart>> GetActiveCarts(bool trackChange);
        Task<Cart?> GetCartById(Guid? id, bool trackChange);
        void UpdateCart(Cart cart);
        void DeleteCart(Guid id, bool trackChange);
        void HardDeleteCart(Guid id, bool trackChange);
    }
}
