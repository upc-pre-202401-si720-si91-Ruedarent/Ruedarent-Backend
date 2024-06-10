using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Queries;
using RuedarentApi.Vehicle.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Services;

namespace RuedarentApi.Vehicle.Application.Internal.QueryService;

public class FavoriteSourceQueryService(IFavoriteSourceRepository favoriteSourceRepository) :
    IFavoriteSourceQueryService
{
    public async Task<FavoriteSource> Handle(GetFavoriteSourceByVehicleApiKeyANDSourceIdQuery query)
    {
        return await favoriteSourceRepository.FindByVehiclesApiKeyAndSourceIdAsync(query.VehicleApiKey, query.SourceId);
    }

    public async Task<FavoriteSource> Handle(GetFavoriteSourceByIdQuery query)
    {
        return await favoriteSourceRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<FavoriteSource>> Handle(GetFavoriteSourceByVehicleApiKeyQuery query)
    {
        return await favoriteSourceRepository.FindByVehiclesApiKeyAsync(query.VehicleApiKey);
    }
}