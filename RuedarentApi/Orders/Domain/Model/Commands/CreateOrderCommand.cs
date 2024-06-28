namespace RuedarentApi.Orders.Domain.Model.Commands;

public record CreateOrderCommand(string OwnerName, int PlanId,double Discount, double Subtotal, double Total);