namespace RuedarentApi.Orders.Interfaces.REST.Resources;

public record CreateOrderResource(string OwnerName,
    string SelectedPlan,
    double Discount,
    double Subtotal,
    double Total);