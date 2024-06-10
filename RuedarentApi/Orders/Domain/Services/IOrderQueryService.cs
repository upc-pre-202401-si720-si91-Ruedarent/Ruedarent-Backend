using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Orders.Domain.Model.Queries;

namespace RuedarentApi.Orders.Domain.Services;

public interface IOrderQueryService
{
    
    Task<IEnumerable<Order>> Handle(GetOrderByOwnerNameQuery query);

    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);

    Task<Order> Handle(GetOrderByIdQuery query);
}