namespace RuedarentApi.Vehicle.Domain.Model.Commands;

public record CreateVehicleSourceCommand(string VehicleApiKey, string SourceId, string VehicleName, string VehicleType, int VehicleUserId);