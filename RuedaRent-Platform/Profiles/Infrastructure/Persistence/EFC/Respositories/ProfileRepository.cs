using ACME.LearningCenter_Platform.Shared.Infraestructure.Persistence.EFC.Repositories;
using ACME.LearningCenter_Platform.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenter_Platform.Profiles;

public class ProfileRepository(AppDbContext context) :
    BaseRepository<Profile>(context), IProfileRepository
{
    public Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().Where(p => p.Email == email)
            .FirstOrDefaultAsync();
    }
}