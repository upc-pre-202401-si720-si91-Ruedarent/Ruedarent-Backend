using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Shared.Domain.Repositories;

namespace RuedarentApi.Orders.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> FindByOwnerNameAsync(string ownerName);
    
    Task<IEnumerable<Order>> GetAllAsync();
    
    //
    Task DeleteOrderAsync(Order order);
}