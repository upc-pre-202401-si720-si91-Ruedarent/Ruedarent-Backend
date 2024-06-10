using RuedarentApi.Orders.Domain.Model.Commands;

namespace RuedarentApi.Orders.Domain.Model.Aggregates;

/// Order Aggregate
/// <summary>
/// This class represents the order aggregate.
/// It is used to store the order of a user.
/// </summary>
///
public class Order
{
    public int Id { get; private set; }
    public string OwnerName { get; private set; }
    public string SelectedPlan { get; private set; }
    public double Discount { get; private set; }
    public double Subtotal { get; private set; }
    public double Total { get; private set; }
    
    protected Order()
    {
        this.OwnerName = string.Empty;
        this.SelectedPlan = string.Empty;
        this.Discount = 0;
        this.Subtotal = 0;
        this.Total = 0;
    }
    
    /// <summary>
    /// Constructor for the Order aggregate
    /// </summary>
    /// <remarks>
    /// the constructor is the command handler for the CreateOrderCommand
    /// </remarks>
    /// <param name="command">the CreateOrderCommand command</param>
    public Order(CreateOrderCommand command)
    {
        this.OwnerName = command.OwnerName;
        this.SelectedPlan = command.SelectedPlan;
        this.Discount = command.Discount;
        this.Subtotal = command.Subtotal;
        if (this.Subtotal == 0)
        {
            this.Discount = 0;
            this.Total = 0;
        }
        else
        {
            this.Total = this.Subtotal - this.Discount;
        }
    }
}