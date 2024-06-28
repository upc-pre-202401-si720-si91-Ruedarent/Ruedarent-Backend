namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Commands;

public record AddImageAssetToVehicleCommand(
    string ImageUrl,
    int TutorialId);