using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;

namespace RuedarentApi.Vehicle.Domain.Repositories;

public interface IFavoriteSourceRepository : IBaseRepository<FavoriteSource>
{
    Task<IEnumerable<FavoriteSource>> FindByVehiclesApiKeyAsync(string vehiclesApiKey);

    Task<FavoriteSource> FindByVehiclesApiKeyAndSourceIdAsync(string vehiclesApiKey, string sourceId);

    Task<IEnumerable<FavoriteSource>> FindByVehicleUserIdAsync(int vehicleUserId);
    
    Task DeleteFavoriteSourceAsync(FavoriteSource favoriteSource);
    
    
}