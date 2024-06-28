using System.Threading.Tasks;
using RuedarentApi.Payment.Domain.Model.Aggregates;
using RuedarentApi.Payment.Domain.Model.Commands;
using RuedarentApi.Payment.Domain.Repositories;
using RuedarentApi.Payment.Domain.Services;

namespace RuedarentApi.Payment.Application.Internal.CommandServices
{
    public class PaymentCommandService : IPaymentCommandService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentCommandService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task CreatePaymentAsync(CreatePaymentCommand command)
        {
            var payment = new Domain.Model.Aggregates.Payment(command.OrderId, command.Amount, command.PaymentMethod);

            if (payment.Validate())
            {
                await _paymentRepository.CreateAsync(payment);
            }
        }
    }
}