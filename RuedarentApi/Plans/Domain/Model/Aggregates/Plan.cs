using RuedarentApi.Orders.Domain.Model.Aggregates;

namespace RuedarentApi.Plans.Domain.Model.Aggregates;

public class Plan
{
    public int PlanId { get;  set; }
    public string Name { get; set; }
    public string Description { get;  set; }
    public double Price { get; set; }
        
    public Plan()
    {
        this.PlanId = 1;
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.Price = 0;
    }

    public Plan(int planId, string name, string description, double price)
    {
        this.PlanId = planId;
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }
    
    public ICollection<Order> Orders { get; set; }
}