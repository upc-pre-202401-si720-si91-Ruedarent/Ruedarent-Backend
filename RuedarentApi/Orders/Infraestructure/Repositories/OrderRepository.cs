using Microsoft.EntityFrameworkCore;
using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Orders.Domain.Repositories;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;

namespace RuedarentApi.Orders.Infraestructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> FindByOwnerNameAsync(string ownerName)
    {
        return await Context.Set<Order>().Where(o => o.OwnerName == ownerName).ToListAsync();
    }

    public async  Task<IEnumerable<Order>> GetAllAsync()
    {
        return await Context.Set<Order>().ToListAsync();
    }
    
    //
    public async Task DeleteOrderAsync(Order order)
    {
        Remove(order);
        await Context.SaveChangesAsync();
    }
}