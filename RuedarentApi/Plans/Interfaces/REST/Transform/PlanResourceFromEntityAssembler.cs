using RuedarentApi.Orders.Interfaces.REST.Resources;
using RuedarentApi.Plans.Domain.Model.Aggregates;
using RuedarentApi.Plans.Interfaces.REST.Resources;

namespace RuedarentApi.Plans.Interfaces.REST.Transform;

public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity)
        => new PlanResource(entity.PlanId, entity.Name, entity.Description,entity.Price);
}