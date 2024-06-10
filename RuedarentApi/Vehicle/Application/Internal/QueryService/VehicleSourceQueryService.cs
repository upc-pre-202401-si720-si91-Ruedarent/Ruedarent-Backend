using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Queries;
using RuedarentApi.Vehicle.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Services;

namespace RuedarentApi.Vehicle.Application.Internal.QueryService;

public class VehicleSourceQueryService(IVehicleSourceRepository vehicleSourceRepository) :
    IVehicleSourceQueryService
{
    public async Task<VehicleSource> Handle(GetVehicleSourceByVehicleApiKeyANDSourceIdQuery query)
    {
        return await vehicleSourceRepository.FindByVehiclesApiKeyAndSourceIdAsync(query.VehicleApiKey, query.SourceId);
    }

    public async Task<VehicleSource> Handle(GetVehicleSourceByIdQuery query)
    {
        return await vehicleSourceRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<VehicleSource>> Handle(GetVehicleSourceByVehicleApiKeyQuery query)
    {
        return await vehicleSourceRepository.FindByVehiclesApiKeyAsync(query.VehicleApiKey);
    }
}