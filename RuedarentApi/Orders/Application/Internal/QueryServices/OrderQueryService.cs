
using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Orders.Domain.Model.Queries;
using RuedarentApi.Orders.Domain.Repositories;
using RuedarentApi.Orders.Domain.Services;

namespace RuedarentApi.Orders.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository) 
    : IOrderQueryService
{
    public async Task<Order> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<Order>> Handle(GetOrderByOwnerNameQuery query)
    {
        return await orderRepository.FindByOwnerNameAsync(query.OwnerName);
    }
    
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
    {
        return await orderRepository.ListAsync();
    }
}