

using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Commands;
using ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Resources;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Transform;

public class AddImageAssetToVehicleCommandFromResourceAssembler
{
    public static AddImageAssetToVehicleCommand ToCommandFromResource(
        AddImageAssetToTutorialResource addImageAssetToTutorialResource,
        int tutorialId)
    {
        return new AddImageAssetToVehicleCommand(addImageAssetToTutorialResource.ImageUrl, tutorialId);
    }
}