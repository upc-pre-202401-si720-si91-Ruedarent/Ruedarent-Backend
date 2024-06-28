using RuedarentApi.Plans.Domain.Model.Aggregates;
using RuedarentApi.Shared.Domain.Repositories;

namespace RuedarentApi.Plans.Domain.Repositories;

public interface IPlanRepository:IBaseRepository<Plan>
{
    Task<IEnumerable<Plan>> GetAllAsync();
}