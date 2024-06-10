using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Interface.REST.Resource;

namespace RuedarentApi.Vehicle.Interface.REST.Transform;

public static class VehicleSourceResourceFromEntityAssembler
{
    public static VehicleSourceResource toResourceFromEntity(VehicleSource entity) =>
        new VehicleSourceResource(entity.Id, entity.VehiclesApiKey, entity.SourceId, entity.VehicleName, entity.VehicleType, entity.VehicleUserId);
}