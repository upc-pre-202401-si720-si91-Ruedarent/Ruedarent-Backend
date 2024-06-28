
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Commands;
using ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Resources;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Transform;

public static class CreateVehicleCommandFromResourceAssembler
{
    public static CreateVehicleCommand ToCommandFromResource(CreateTutorialResource resource)
    {
        return new CreateVehicleCommand(resource.VehicleName, resource.Description, resource.CategoryId);
    }
}