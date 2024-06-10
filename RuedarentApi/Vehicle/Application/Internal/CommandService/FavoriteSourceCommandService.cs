using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Commands;
using RuedarentApi.Vehicle.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Services;

namespace RuedarentApi.Vehicle.Application.Internal.CommandService;

public class FavoriteSourceCommandService(IFavoriteSourceRepository favoriteSourceRepository
    , IUnitOfWork unitOfWork) : IFavoriteSourceCommandService
{
    public async Task<FavoriteSource> Handle(CreateFavoriteSourceCommand command)
    {
        var favoriteSource = await
            favoriteSourceRepository.FindByVehiclesApiKeyAndSourceIdAsync(command.VehicleApiKey, command.SourceId);
        if (favoriteSource != null)
            throw new Exception("Favorite source with this SourceId already exists for the given VehicleApiKey");
        favoriteSource = new FavoriteSource(command);
        await favoriteSourceRepository.AddAsync(favoriteSource);
        await unitOfWork.CompleteAsync();
        return favoriteSource;
    }

   
}