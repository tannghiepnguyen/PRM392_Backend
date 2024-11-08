using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Categories.DTO;
using PRM392_Backend.Service.Payments.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Payments
{
    public interface IPaymentService
    {
        // Task<Payment> GetPaymentById(Guid id);
        Task<IEnumerable<PaymentResponse>> GetAllPayments(bool trackChange);
        Task<string>CreatePayment(PaymentRequest payment);
        Task<string> UpdatePayment(long OrderCode);
        //Task<IEnumerable<Payment>> GetAllPayments();
    }
} 