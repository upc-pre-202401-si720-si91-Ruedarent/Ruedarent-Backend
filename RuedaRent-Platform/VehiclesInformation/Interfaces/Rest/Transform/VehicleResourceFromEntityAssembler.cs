
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;
using ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Resources;
using ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Transform;
using Microsoft.OpenApi.Extensions;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Transform;

public static class VehicleResourceFromEntityAssembler
{
    public static VehicleResource ToResourceFromEntity(Vehicle vehicle)
    {
        return new VehicleResource(
            vehicle.Id,
            vehicle.VehicleName,
            vehicle.Description,
            CategoryResourceFromEntityAssembler.ToResourceFromEntity(vehicle.Category),
            vehicle.Status.GetDisplayName());
    }
}