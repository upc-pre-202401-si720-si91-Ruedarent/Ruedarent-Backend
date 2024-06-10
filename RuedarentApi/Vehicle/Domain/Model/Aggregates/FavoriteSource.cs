using RuedarentApi.Vehicle.Domain.Model.Commands;

namespace RuedarentApi.Vehicle.Domain.Model.Aggregates;

///FavoriteSource Aggregate
/// <summary>
/// This Class  represents the favoriteSource aggregate.
/// It is used to store the favorite source of a user.
/// </summary>

public class FavoriteSource
{
    public int Id { get; private set; }
    public string VehiclesApiKey { get; private set; }
    public string SourceId { get; private set; }
    
    public string VehicleName { get; private set; }
    
    public string VehicleType { get; private set; }
    
    public int VehicleUserId { get; private set; }
    
    

    protected FavoriteSource()
    {
        this.VehiclesApiKey = string.Empty;
        this.SourceId = string.Empty;
        this.VehicleName = string.Empty;
        this.VehicleType = string.Empty;
        this.VehicleUserId = 0;
    }
    
    /// <summary>
    /// Constructor for the FavoriteSource aggregate
    /// </summary>
    /// <remarks>the constructor is the command handler for the createfavoritesourcecommand</remarks>
    /// <param name="command"></param>

    public FavoriteSource(CreateFavoriteSourceCommand command)
    {
        this.VehiclesApiKey = command.VehicleApiKey;
        this.SourceId = command.SourceId;
        this.VehicleName = command.VehicleName;
        this.VehicleType = command.VehicleType;
        this.VehicleUserId = command.VehicleUserId;
    }
    
}