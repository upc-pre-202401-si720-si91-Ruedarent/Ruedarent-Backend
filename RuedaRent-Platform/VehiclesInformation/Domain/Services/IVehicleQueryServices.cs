
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Queries;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Services;

public interface IVehicleQueryServices
{
    Task<Vehicle?> Handle(GetVehicleByIdQuery query);

    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query);

    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesByCategoryIdQuery query);
}