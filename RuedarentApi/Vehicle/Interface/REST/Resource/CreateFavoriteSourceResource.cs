namespace RuedarentApi.Vehicle.Interface.REST.Resource;

public record CreateFavoriteSourceResource(string VehiclesApiKey, string SourceId, string VehicleName, string VehicleType, int VehicleUserId);