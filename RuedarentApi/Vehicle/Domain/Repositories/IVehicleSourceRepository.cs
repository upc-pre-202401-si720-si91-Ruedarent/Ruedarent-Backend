using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;

namespace RuedarentApi.Vehicle.Domain.Repositories;

public interface IVehicleSourceRepository : IBaseRepository<VehicleSource>
{
    Task<IEnumerable<VehicleSource>> FindByVehiclesApiKeyAsync(string vehiclesApiKey);

    Task<VehicleSource> FindByVehiclesApiKeyAndSourceIdAsync(string vehiclesApiKey, string sourceId);

    Task<IEnumerable<VehicleSource>> FindByVehicleUserIdAsync(int vehicleUserId);
    
    Task DeleteFavoriteSourceAsync(VehicleSource vehicleSource);
    
    
}