namespace RuedarentApi.Vehicle.Domain.Model.Commands;

public record CreateFavoriteSourceCommand(string VehicleApiKey, string SourceId, string VehicleName, string VehicleType, int VehicleUserId);