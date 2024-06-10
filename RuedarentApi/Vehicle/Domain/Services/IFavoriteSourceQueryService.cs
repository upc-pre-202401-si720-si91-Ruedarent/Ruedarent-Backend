using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Queries;

namespace RuedarentApi.Vehicle.Domain.Services;

public interface IFavoriteSourceQueryService
{
    Task<IEnumerable<FavoriteSource>> Handle(GetFavoriteSourceByVehicleApiKeyQuery query);
    Task<FavoriteSource> Handle(GetFavoriteSourceByVehicleApiKeyANDSourceIdQuery query);
    Task<FavoriteSource> Handle(GetFavoriteSourceByIdQuery query);
}