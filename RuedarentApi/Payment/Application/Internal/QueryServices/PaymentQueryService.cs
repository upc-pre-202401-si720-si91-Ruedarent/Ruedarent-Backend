using System;
using System.Threading.Tasks;
using RuedarentApi.Payment.Domain.Model.Aggregates;
using RuedarentApi.Payment.Domain.Repositories;
using RuedarentApi.Payment.Domain.Services;

namespace RuedarentApi.Payment.Application.Internal.QueryServices
{
    public class PaymentQueryService : IPaymentQueryService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentQueryService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        
        public async Task<Domain.Model.Aggregates.Payment> GetPaymentByIdAsync(Guid paymentId)
        {
            return await _paymentRepository.GetByIdAsync(paymentId);
        }
    }
}