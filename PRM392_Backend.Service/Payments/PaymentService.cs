using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PRM392_Backend.Service.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PaymentService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Payment> GetPaymentById(Guid id) =>
            await _repositoryManager.PaymentRepository.GetPaymentById(id);

        public async Task CreatePayment(Payment payment)
        {
            try
            {
                Console.WriteLine($"Creating payment: OrderID={payment.OrderID}, Amount={payment.Amount}, PaymentStatus={payment.PaymentStatus}");

                _repositoryManager.PaymentRepository.CreatePayment(payment);
                await _repositoryManager.PaymentRepository.SaveAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Database update error occurred while saving the payment.", dbEx.InnerException);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the payment.", ex);
            }
        }

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _repositoryManager.PaymentRepository.GetAllPayments();
        }
    }
} 