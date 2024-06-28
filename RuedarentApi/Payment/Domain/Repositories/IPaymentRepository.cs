using System;
using System.Threading.Tasks;
using RuedarentApi.Payment.Domain.Model.Aggregates;

namespace RuedarentApi.Payment.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<Model.Aggregates.Payment> GetByIdAsync(Guid paymentId);
        Task CreateAsync(Model.Aggregates.Payment payment);
    }
}