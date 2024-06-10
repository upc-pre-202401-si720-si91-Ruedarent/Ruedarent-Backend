using Microsoft.EntityFrameworkCore;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Repositories;

namespace RuedarentApi.Vehicle.Infraestructure.Repositories;

public class VehicleSourceRepository : BaseRepository<VehicleSource>, IVehicleSourceRepository
{
    public VehicleSourceRepository(AppDBContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<VehicleSource>> FindByVehiclesApiKeyAsync(string vehiclesApiKey)
    {
        return await Context.Set<VehicleSource>().Where(f => f.VehiclesApiKey == vehiclesApiKey).ToListAsync();
    }

    public async Task<VehicleSource?> FindByVehiclesApiKeyAndSourceIdAsync(string vehiclesApiKey, string sourceId)
    {
        return await Context.Set<VehicleSource>()
            .FirstOrDefaultAsync(f => f.VehiclesApiKey == vehiclesApiKey && f.SourceId == sourceId);
    }

    

    public async Task<IEnumerable<VehicleSource>> FindByVehicleUserIdAsync(int vehicleUserId)
    {
        return await Context.Set<VehicleSource>()
            .Where(f => f.VehicleUserId == vehicleUserId)
            .ToListAsync();
    }

    public async Task DeleteFavoriteSourceAsync(VehicleSource vehicleSource)
    {
        Remove(vehicleSource);
        await Context.SaveChangesAsync();
    }
    
    
}