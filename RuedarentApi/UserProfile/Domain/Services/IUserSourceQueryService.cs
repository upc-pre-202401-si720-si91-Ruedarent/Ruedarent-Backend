using RuedarentApi.UserProfile.Domain.Model.Aggregates;
using RuedarentApi.UserProfile.Domain.Model.Queries;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;

namespace RuedarentApi.UserProfile.Domain.Services;

public interface IUserSourceQueryService
{
    Task<UserSource> Handle(GetUserSourceByDNIQuery query);
    Task<UserSource> Handle(GetUserSourceByIdQuery query);
}