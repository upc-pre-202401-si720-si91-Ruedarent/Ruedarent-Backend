using ACME.LearningCenter_Platform.Shared.Domain.Repositories;

namespace ACME.LearningCenter_Platform.IAM;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);

    bool ExistsByUsername(string username);
}