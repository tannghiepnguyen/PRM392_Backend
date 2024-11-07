using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Orders.DTO;
using PRM392_Backend.Service.Payments.DTO;
using PRM392_Backend.Service.Service;

namespace PRM392_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public PaymentController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }


        [HttpGet]
        [Authorize(Roles = Roles.Customer)]
        public async Task<IActionResult> GetPayments()
        {
            var categories = await serviceManager.PaymentService.GetAllPayments(trackChange: false);
            return Ok(categories);
        }


        [HttpGet]
        [Route("success")]
      //  [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetSuccess(long orderCode, Guid orderId, string userId)
        {
            var result = await serviceManager.PaymentService.UpdatePayment(orderCode, orderId, userId);
            if (result != null)
            {
                return Ok("Payment has been paid");
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("cancel")]
       // [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetCancel(long orderCode, Guid orderId, string userId)
        {
            var result = await serviceManager.PaymentService.UpdatePayment(orderCode, orderId, userId);
            if (result != null)
            {
                return Ok("Payment has been canceled");
            }
            return BadRequest(result);
        }


        [HttpPost]
        [Route("checkout")]
        [Authorize(Roles = Roles.Customer)]
        public async Task<IActionResult> CreatePayment([FromForm] PaymentRequest request)
        {
            var result = await serviceManager.PaymentService.CreatePayment(request);
            return Ok(result);
        }


    }
}
