using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Orders.Interfaces.REST.Resources;

namespace RuedarentApi.Orders.Interfaces.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order entity)
        => new OrderResource(entity.Id, entity.OwnerName, entity.PlanId,entity.Discount,entity.Subtotal,entity.Total);
}