using RuedarentApi.Plans.Domain.Model.Aggregates;
using RuedarentApi.Plans.Domain.Model.Queries;

namespace RuedarentApi.Plans.Domain.Services;

public interface IPlanQueryService
{
    Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query);

    Task<Plan> Handle(GetPlanByIdQuery query);
}