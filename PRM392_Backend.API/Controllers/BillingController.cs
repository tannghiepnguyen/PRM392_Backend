using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Service.Orders.DTO;
using PRM392_Backend.Service.Orders;
using PRM392_Backend.Service.Payments;
using PRM392_Backend.Domain.Models;
using System.Threading.Tasks;
using System;
using PRM392_Backend.Service.IService;
using System.Collections.Generic;

namespace PRM392_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IServiceManager serviceManager; 

        public BillingController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            if (paymentRequest.OrderID == Guid.Empty || paymentRequest.Amount <= 0)
            {
                return BadRequest("Invalid payment request.");
            }

            var payment = new Payment
            {
                OrderID = paymentRequest.OrderID,
                Amount = paymentRequest.Amount,
                PaymentDate = DateTime.UtcNow,
                PaymentStatus = paymentRequest.PaymentStatus
            };
            await serviceManager.PaymentService.CreatePayment(payment);

            return Ok(new { Message = "Payment processed successfully", PaymentStatus = "Success" });
        }

        [HttpGet("GetAllBilling")]
        public async Task<IActionResult> GetAllBilling()
        {
            var payments = await serviceManager.PaymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("GetPayment/{id}")]
        public async Task<IActionResult> GetPayment(string id)
        {
            if (!Guid.TryParse(id, out Guid paymentId))
            {
                return BadRequest("ID không hợp lệ.");
            }

            var payment = await serviceManager.PaymentService.GetPaymentById(paymentId);
            if (payment == null)
            {
                return NotFound("Không tìm thấy thanh toán.");
            }

            return Ok(payment);
        }
    }

    public class PaymentRequest
    {
        public Guid OrderID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
    }
} 