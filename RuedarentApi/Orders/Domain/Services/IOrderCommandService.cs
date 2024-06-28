using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Orders.Domain.Model.Commands;
using RuedarentApi.Plans.Domain.Model.Aggregates;

namespace RuedarentApi.Orders.Domain.Services;

public interface IOrderCommandService
{
    Task<Order> Handle(CreateOrderCommand command, Plan plan);
}