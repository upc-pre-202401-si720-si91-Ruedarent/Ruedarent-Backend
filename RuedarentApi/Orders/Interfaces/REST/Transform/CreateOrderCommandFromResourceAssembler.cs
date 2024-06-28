using RuedarentApi.Orders.Domain.Model.Commands;
using RuedarentApi.Orders.Interfaces.REST.Resources;

namespace RuedarentApi.Orders.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand
        ToCommandFromResource(CreateOrderResource resource) =>
        new CreateOrderCommand(resource.OwnerName, resource.PlanId,resource.Discount,resource.Subtotal,resource.Total);
}