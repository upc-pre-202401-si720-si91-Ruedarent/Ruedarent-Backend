namespace RuedarentApi.Vehicle.Interface.REST.Resource;

public record FavoriteSourceResource(int Id, string VehiclesApiKey, string SourceId, string VehicleName, string VehicleType, int VehicleUserId);
