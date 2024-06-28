
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Queries;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Repositories;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Services;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Application.Internal.QueryServices;

public class VehicleQueryService(IVehicleRepository vehicleRepository) : IVehicleQueryServices
{
    public async Task<Vehicle?> Handle(GetVehicleByIdQuery query)
    {
        return await vehicleRepository.FindByIdAsync(query.TutorialId);
    }

    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query)
    {
        return await vehicleRepository.ListAsync();
    }

    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesByCategoryIdQuery query)
    {
        return await vehicleRepository.FindByCategoryIdAsync(query.CategoryId);
    }
}