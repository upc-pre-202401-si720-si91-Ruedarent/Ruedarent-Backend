using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Commands;
using RuedarentApi.Vehicle.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Services;

namespace RuedarentApi.Vehicle.Application.Internal.CommandService;

public class VehicleSourceCommandService(IVehicleSourceRepository vehicleSourceRepository
    , IUnitOfWork unitOfWork) : IVehicleSourceCommandService
{
    public async Task<VehicleSource> Handle(CreateVehicleSourceCommand command)
    {
        var favoriteSource = await
            vehicleSourceRepository.FindByVehiclesApiKeyAndSourceIdAsync(command.VehicleApiKey, command.SourceId);
        if (favoriteSource != null)
            throw new Exception("Favorite source with this SourceId already exists for the given VehicleApiKey");
        favoriteSource = new VehicleSource(command);
        await vehicleSourceRepository.AddAsync(favoriteSource);
        await unitOfWork.CompleteAsync();
        return favoriteSource;
    }

   
}