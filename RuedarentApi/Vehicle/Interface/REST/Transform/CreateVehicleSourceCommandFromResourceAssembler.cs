using RuedarentApi.Vehicle.Domain.Model.Commands;
using RuedarentApi.Vehicle.Interface.REST.Resource;

namespace RuedarentApi.Vehicle.Interface.REST.Transform;

public class CreateVehicleSourceCommandFromResourceAssembler
{
    public static CreateVehicleSourceCommand
        ToCommandFromResource(CreateVehicleSourceResource resource) =>
        new CreateVehicleSourceCommand(resource.VehiclesApiKey, resource.SourceId, resource.VehicleName, resource.VehicleType, resource.VehicleUserId);
}