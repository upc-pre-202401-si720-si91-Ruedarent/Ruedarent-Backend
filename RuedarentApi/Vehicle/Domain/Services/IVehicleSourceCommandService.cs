using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Commands;

namespace RuedarentApi.Vehicle.Domain.Services;

public interface IVehicleSourceCommandService
{
    Task<VehicleSource> Handle(CreateVehicleSourceCommand command);
}