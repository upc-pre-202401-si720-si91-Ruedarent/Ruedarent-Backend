using Microsoft.EntityFrameworkCore;
using RuedarentApi.Plans.Domain.Model.Aggregates;
using RuedarentApi.Plans.Domain.Repositories;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;

namespace RuedarentApi.Plans.Infraestructure.Repositories;

public class PlanRepository: BaseRepository<Plan>, IPlanRepository
{
    public PlanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Plan>> GetAllAsync()
    {
        return await Context.Set<Plan>().ToListAsync();
    }
    
    

}