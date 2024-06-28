using RuedarentApi.Orders.Domain.Model.Queries;
using RuedarentApi.Plans.Domain.Model.Aggregates;
using RuedarentApi.Plans.Domain.Model.Queries;
using RuedarentApi.Plans.Domain.Repositories;
using RuedarentApi.Plans.Domain.Services;

namespace RuedarentApi.Plans.Application.Internal.QueryServices;

public class PlanQueryService(IPlanRepository planRepository) 
    : IPlanQueryService
{
    public async Task<Plan> Handle(GetPlanByIdQuery query)
    {
        return await planRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query)
    {
        return await planRepository.ListAsync();
    }
}
