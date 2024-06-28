using System;
using System.Threading.Tasks;
using RuedarentApi.Payment.Domain.Model.Aggregates;

namespace RuedarentApi.Payment.Domain.Services
{
    public interface IPaymentQueryService
    {
        Task<Model.Aggregates.Payment> GetPaymentByIdAsync(Guid paymentId);
    }
}