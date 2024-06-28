
using ACME.LearningCenter_Platform.Shared.Domain.Repositories;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> FindByCategoryIdAsync(int categoryId);
}