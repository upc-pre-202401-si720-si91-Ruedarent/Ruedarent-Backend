using Microsoft.EntityFrameworkCore;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Repositories;

namespace RuedarentApi.Vehicle.Infraestructure.Repositories;

public class FavoriteSourceRepository : BaseRepository<FavoriteSource>, IFavoriteSourceRepository
{
    public FavoriteSourceRepository(AppDBContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<FavoriteSource>> FindByVehiclesApiKeyAsync(string vehiclesApiKey)
    {
        return await Context.Set<FavoriteSource>().Where(f => f.VehiclesApiKey == vehiclesApiKey).ToListAsync();
    }

    public async Task<FavoriteSource?> FindByVehiclesApiKeyAndSourceIdAsync(string vehiclesApiKey, string sourceId)
    {
        return await Context.Set<FavoriteSource>()
            .FirstOrDefaultAsync(f => f.VehiclesApiKey == vehiclesApiKey && f.SourceId == sourceId);
    }

    

    public async Task<IEnumerable<FavoriteSource>> FindByVehicleUserIdAsync(int vehicleUserId)
    {
        return await Context.Set<FavoriteSource>()
            .Where(f => f.VehicleUserId == vehicleUserId)
            .ToListAsync();
    }

    public async Task DeleteFavoriteSourceAsync(FavoriteSource favoriteSource)
    {
        Remove(favoriteSource);
        await Context.SaveChangesAsync();
    }
    
    
}