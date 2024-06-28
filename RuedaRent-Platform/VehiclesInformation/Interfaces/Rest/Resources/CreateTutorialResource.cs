namespace ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Resources;

public record CreateTutorialResource(
    string VehicleName,
    string Description,
    int CategoryId);