using RuedarentApi.Vehicle.Domain.Model.Commands;
using RuedarentApi.Vehicle.Interface.REST.Resource;

namespace RuedarentApi.Vehicle.Interface.REST.Transform;

public class CreateFavoriteSourceCommandFromResourceAssembler
{
    public static CreateFavoriteSourceCommand
        ToCommandFromResource(CreateFavoriteSourceResource resource) =>
        new CreateFavoriteSourceCommand(resource.VehiclesApiKey, resource.SourceId, resource.VehicleName, resource.VehicleType, resource.VehicleUserId);
}