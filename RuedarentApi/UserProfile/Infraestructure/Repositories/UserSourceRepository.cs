using Microsoft.EntityFrameworkCore;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;
using RuedarentApi.UserProfile.Domain.Model.Aggregates;
using RuedarentApi.UserProfile.Domain.Repositories;

namespace RuedarentApi.UserProfile.Infraestructure.Repositories;

public class UserSourceRepository : BaseRepository<UserSource>, IUserSourceRepository
{
    public UserSourceRepository(AppDbContext context) : base(context)
    {
        
    }

   
    
    public async Task<UserSource?> FindByUserDNIAsync(int DNI)
    {
        return await Context.Set<UserSource>()
            .FirstOrDefaultAsync(f => f.Dni == DNI);
    }
    
    public async Task DeleteUser(UserSource userSource)
    {
        Remove(userSource);
        await Context.SaveChangesAsync();
    }
    
}