using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRM392_Backend.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DatabaseContext _context;

        public PaymentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Payment> GetPaymentById(Guid id) =>
            await _context.Payments.FindAsync(id);

        public void CreatePayment(Payment payment) => _context.Payments.Add(payment);

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }
    }
} 