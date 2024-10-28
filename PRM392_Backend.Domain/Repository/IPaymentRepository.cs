using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentById(Guid id);
        void CreatePayment(Payment payment);
        Task SaveAsync();
        Task<IEnumerable<Payment>> GetAllPayments();
    }
} 