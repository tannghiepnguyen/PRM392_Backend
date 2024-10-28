using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Payments
{
    public interface IPaymentService
    {
        Task<Payment> GetPaymentById(Guid id);
        Task CreatePayment(Payment payment);
        Task<IEnumerable<Payment>> GetAllPayments();
    }
} 