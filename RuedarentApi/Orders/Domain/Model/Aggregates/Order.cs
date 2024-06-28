using RuedarentApi.Orders.Domain.Model.Commands;
using RuedarentApi.Plans.Domain.Model.Aggregates;

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
    public int PlanId { get; internal set; }
    public Plan Plan { get; private set; }
    public double Discount { get; private set; }
    public double Subtotal { get; private set; }
    public double Total { get; private set; }
    
    protected Order()
    {
        this.OwnerName = string.Empty;
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
    public Order(CreateOrderCommand command, Plan plan)
    {
        this.OwnerName = command.OwnerName;
        this.Plan = plan;
        this.PlanId = plan.PlanId;
        this.Discount = command.Discount;
        this.Subtotal = plan.Price;
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