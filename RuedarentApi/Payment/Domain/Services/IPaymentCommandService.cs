using System.Threading.Tasks;
using RuedarentApi.Payment.Domain.Model.Commands;

namespace RuedarentApi.Payment.Domain.Services
{
    public interface IPaymentCommandService
    {
        Task CreatePaymentAsync(CreatePaymentCommand command);
    }
}