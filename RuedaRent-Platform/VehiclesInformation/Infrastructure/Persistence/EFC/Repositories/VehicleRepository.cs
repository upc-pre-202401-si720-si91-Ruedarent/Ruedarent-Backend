
using ACME.LearningCenter_Platform.Shared.Infraestructure.Persistence.EFC.Repositories;
using ACME.LearningCenter_Platform.Shared.Interfaces.ASP.Configuration;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Infrastructure.Persistence.EFC.Repositories;

public class VehicleRepository(AppDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    public new async Task<Vehicle?> FindByIdAsync(int id)
    {
        return await Context.Set<Vehicle>().Include(t => t.Category)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Vehicle>> FindByCategoryIdAsync(int categoryId)
    {
        return await Context.Set<Vehicle>()
            .Include(tutorial => tutorial.Category)
            .Where(tutorial => tutorial.CategoryId == categoryId)
            .ToListAsync();
    }
}