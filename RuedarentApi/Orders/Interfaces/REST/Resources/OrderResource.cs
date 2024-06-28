namespace RuedarentApi.Orders.Interfaces.REST.Resources;

public record OrderResource(
    int Id,
    string OwnerName,
    int PlanId,
    double Discount,
    double Subtotal,
    double Total);