namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Commands;

public record CreateVehicleCommand(string VehicleName, string Description, int CategoryId);