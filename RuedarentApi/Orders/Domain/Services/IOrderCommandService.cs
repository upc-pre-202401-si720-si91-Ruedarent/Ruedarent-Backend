using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Orders.Domain.Model.Commands;

namespace RuedarentApi.Orders.Domain.Services;

public interface IOrderCommandService
{
    Task<Order> Handle(CreateOrderCommand command);
}