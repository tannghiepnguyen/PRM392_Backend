using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PRM392_Backend.Service.Payments.DTO;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using PRM392_Backend.Domain.Exceptions;
using Net.payOS.Types;
using PRM392_Backend.Service.PayOSLib;
using Azure.Core;
using System.Threading;
using PRM392_Backend.Service.Categories.DTO;

namespace PRM392_Backend.Service.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PayOSService _payOSService;

        public PaymentService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, PayOSService payOSService)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _payOSService = payOSService;
        }

        public async Task<IEnumerable<PaymentResponse>> GetAllPayments(bool trackChange)
        {
            var userId = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var payments = await _repositoryManager.PaymentRepository.GetPayments(userId, trackChange);
            return _mapper.Map<IEnumerable<PaymentResponse>>(payments);
        }


        public async Task<string> CreatePayment(PaymentRequest request)
        {
            var userId = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //Order pending to checkout
            var order = _repositoryManager.OrderRepository.GetPendingOrderAndUserId(userId, false);

            if(order == null)
            {
                throw new OrderNotFoundException("You have no Order!");
            }

            var items = order.Cart.CartItems.Select(cartitem => new ItemData(
            cartitem.Product.ProductName,
            cartitem.Quantity,
            (int)cartitem.Product.Price
            )).ToList();

            long orderCode = long.Parse(DateTimeOffset.Now.ToString("yyMMddHHmmss"));
            string domain = "https://deliveroowebapp.azurewebsites.net";
            var totalAmount = items.Sum(item => (int)Math.Ceiling((decimal)item.quantity * item.price));

            var paymentExist = _repositoryManager.PaymentRepository.GetPaymentByOrderId(order.ID, false);
            if (paymentExist == null)
            {
                var payment = new Payment
                {
                    ID = Guid.NewGuid(),
                    Amount = totalAmount,
                    PaymentDate = DateTime.UtcNow,
                    OrderID = order.ID,
                    PaymentStatus = PaymentStatus.Pending.ToString(),
                };

                _repositoryManager.PaymentRepository.CreatePayment(payment);
            }

           

            var payOSModel = new PaymentData(
               orderCode: orderCode,
               amount: totalAmount*25000,
               description: $"Payment - Deliveroo",
               items: items,
               returnUrl: $"{domain}/api/Payment/success?orderCode={orderCode}&orderID={order.ID}&userID={userId}",
               cancelUrl: $"{domain}/api/Payment/cancel?orderCode={orderCode}&orderID={order.ID}&userID={userId}",
               //returnUrl: $"https://localhost:7187/api/Payment/success?orderCode={orderCode}&orderID={order.ID}&userID={userId}",
               //cancelUrl: $"https://localhost:7187/api/Payment/cancel?orderCode={orderCode}&orderID={order.ID}&userID={userId}",
               buyerName: order.User.FullName,
               buyerEmail: order.User.Email,
               buyerPhone: order.User.PhoneNumber,
               buyerAddress: order.BillingAddress
            );

            try
            {
                var paymentUrl = await _payOSService.CreatePaymentLink(payOSModel);           
                if (paymentUrl != null)
                {                  
                    await _repositoryManager.Save();
                    return paymentUrl.checkoutUrl;
                }
      
            }
            catch (Exception ex)
            {         
                throw new PaymentLinkNotFoundException(ex.Message);
            }

            return "Create PaymentLink fail";
        }


        public async Task<string> UpdatePayment(long ordercode, Guid orderId, string userId)
        {          
            //Order pending to checkout
            var order = _repositoryManager.OrderRepository.GetPendingOrderAndUserId(userId, true);

            var payment = _repositoryManager.PaymentRepository.GetPaymentByOrderId(orderId, true);

            if (order == null)
            {
                throw new OrderNotFoundException("You have no Order!");
            }

            var paymentInformation = await _payOSService.GetPaymentLinkInformation(ordercode);
            var cart = _repositoryManager.CartRepository.GetCartActiveAndUserId(order.UserID, true);

            if (paymentInformation != null)
            {
                if (paymentInformation.status.ToUpper() == "PAID")
                {
                    order.OrderStatus = OrderStatus.Processing.ToString();
                    _repositoryManager.OrderRepository.UpdateOrder(order);
                    

                    //Update Cart
                    cart.IsActive = false;
                    cart.Status = CartStatus.Paid.ToString();
                    _repositoryManager.CartRepository.UpdateCart(cart);
                   

                    //Update Payment
                    payment.PaymentStatus = PaymentStatus.Success.ToString();
                    _repositoryManager.PaymentRepository.UpdatePayment(payment);
                    await _repositoryManager.Save();

                    return "The order has been paid.";
                }
                else
                {
                    order.OrderStatus = OrderStatus.Cancel.ToString();
                    _repositoryManager.OrderRepository.UpdateOrder(order);
                   

                    //Update Cart
                    cart.IsActive = false;
                    cart.Status = CartStatus.Unpaid.ToString();
                    _repositoryManager.CartRepository.UpdateCart(cart);
                    

                    //Update Payment
                    payment.PaymentStatus = PaymentStatus.Cancel.ToString();
                    _repositoryManager.PaymentRepository.UpdatePayment(payment);
                    await _repositoryManager.Save();

                    return "The order has been canceled.";
                }

            }
            else
            {
                throw new ApplicationException("Cannot get Payment Information.");
            }
           
        }
    } 
} 