using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.UserProfile.Domain.Model.Aggregates;

namespace RuedarentApi.UserProfile.Domain.Repositories;

public interface IUserSourceRepository : IBaseRepository<UserSource>
{

    
    Task<UserSource> FindByUserDNIAsync(int DNI);
    Task DeleteUser(UserSource UserSource);

}