namespace RuedarentApi.Orders.Interfaces.REST.Resources;

public record CreateOrderResource(string OwnerName,
    int PlanId,
    double Discount,
    double Subtotal,
    double Total);