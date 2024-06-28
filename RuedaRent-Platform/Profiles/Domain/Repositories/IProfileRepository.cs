using ACME.LearningCenter_Platform.Shared.Domain.Repositories;

namespace ACME.LearningCenter_Platform.Profiles;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}