using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuedarentApi.Payment.Application.Internal.CommandServices;
using RuedarentApi.Payment.Application.Internal.QueryServices;
using RuedarentApi.Payment.Domain.Model.Commands;
using RuedarentApi.Payment.Domain.Model.Queries;
using RuedarentApi.Payment.Domain.Services;
using RuedarentApi.Payment.Interfaces.REST.Resources;

namespace RuedarentApi.Payment.Interfaces.REST
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentCommandService _paymentCommandService;
        private readonly IPaymentQueryService _paymentQueryService;

        public PaymentController(IPaymentCommandService paymentCommandService, IPaymentQueryService paymentQueryService)
        {
            _paymentCommandService = paymentCommandService;
            _paymentQueryService = paymentQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
        {
            var command = new CreatePaymentCommand
            {
                OrderId = resource.OrderId,
                Amount = resource.Amount,
                PaymentMethod = resource.PaymentMethod
            };

            await _paymentCommandService.CreatePaymentAsync(command);
            return Ok();
        }

        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPaymentById(Guid paymentId)
        {
            var payment = await _paymentQueryService.GetPaymentByIdAsync(paymentId);
            
            if (payment == null)
                return NotFound();

            var resource = new PaymentResource
            {
                PaymentId = payment.PaymentId,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status
            };

            return Ok(resource);
        }
    }
}