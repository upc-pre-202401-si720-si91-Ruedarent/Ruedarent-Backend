namespace RuedarentApi.Plans.Interfaces.REST.Resources;

public record PlanResource(
    int PlanId, string Name, string Description, double Price
    );
 