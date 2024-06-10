using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Interface.REST.Resource;

namespace RuedarentApi.Vehicle.Interface.REST.Transform;

public static class FavoriteSourceResourceFromEntityAssembler
{
    public static FavoriteSourceResource toResourceFromEntity(FavoriteSource entity) =>
        new FavoriteSourceResource(entity.Id, entity.VehiclesApiKey, entity.SourceId, entity.VehicleName, entity.VehicleType, entity.VehicleUserId);
}