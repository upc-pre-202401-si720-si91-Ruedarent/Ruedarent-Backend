using RuedarentApi.UserProfile.Domain.Model.Aggregates;
using RuedarentApi.UserProfile.Domain.Model.Queries;
using RuedarentApi.UserProfile.Domain.Repositories;
using RuedarentApi.UserProfile.Domain.Services;

namespace RuedarentApi.UserProfile.Application.Internal.QueryService;

public class UserSourceQueryService(IUserSourceRepository userSourceRepository) :
IUserSourceQueryService
{
   
    

    public async Task<UserSource> Handle(GetUserSourceByDNIQuery query)
    {
        return await userSourceRepository.FindByUserDNIAsync(query.DNI);
    }

    public async Task<UserSource> Handle(GetUserSourceByIdQuery query)
    {
        return await userSourceRepository.FindByIdAsync(query.id);
    }
    
}