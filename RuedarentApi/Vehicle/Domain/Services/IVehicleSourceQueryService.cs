using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Queries;

namespace RuedarentApi.Vehicle.Domain.Services;

public interface IVehicleSourceQueryService
{
    Task<IEnumerable<VehicleSource>> Handle(GetVehicleSourceByVehicleApiKeyQuery query);
    Task<VehicleSource> Handle(GetVehicleSourceByVehicleApiKeyANDSourceIdQuery query);
    Task<VehicleSource> Handle(GetVehicleSourceByIdQuery query);
}