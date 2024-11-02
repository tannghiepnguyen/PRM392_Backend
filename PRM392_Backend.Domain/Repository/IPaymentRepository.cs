using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPayments(string userId, bool trackChange);
        Payment GetPaymentByOrderId(Guid id, bool trackChange);
        void CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
    }
}
