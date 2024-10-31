using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Infrastructure.Repository
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {   
        public PaymentRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Payment>> GetPayments(string userId, bool trackChange) => await FindByCondition(p => p.Order.UserID == userId, trackChange).ToListAsync();

        public Payment? GetPaymentByOrderId(Guid id, bool trackChange) 
             =>  FindByCondition(p => p.OrderID == id, trackChange).FirstOrDefault();
        
        public void CreatePayment(Payment payment) => _context.Payments.Add(payment);

        public void UpdatePayment(Payment payment) => Update(payment);


    }
}