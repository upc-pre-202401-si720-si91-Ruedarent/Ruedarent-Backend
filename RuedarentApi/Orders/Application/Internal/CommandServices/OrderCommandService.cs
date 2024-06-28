
using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Orders.Domain.Model.Commands;
using RuedarentApi.Orders.Domain.Repositories;
using RuedarentApi.Orders.Domain.Services;
using RuedarentApi.Plans.Domain.Model.Aggregates;
using RuedarentApi.Plans.Domain.Repositories;
using RuedarentApi.Shared.Domain.Repositories;

namespace RuedarentApi.Orders.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) :IOrderCommandService
{
    public async Task<Order> Handle(CreateOrderCommand command, Plan plan)
    {
        var existingOrder = await orderRepository.FindByOwnerNameAsync(command.OwnerName);
        if (existingOrder.Any())
            throw new
                Exception("Order already exists for the given Name");
        var order = new Order(command, plan);
        await orderRepository.AddAsync(order);
        await unitOfWork.CompleteAsync();
        return order;
    }
}