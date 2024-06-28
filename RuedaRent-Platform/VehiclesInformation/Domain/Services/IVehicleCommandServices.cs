
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Commands;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Services;

public interface IVehicleCommandServices
{
    Task<Vehicle?> Handle(AddImageAssetToVehicleCommand command);

    Task<Vehicle?> Handle(CreateVehicleCommand command);
}