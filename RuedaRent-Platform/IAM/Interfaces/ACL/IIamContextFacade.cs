namespace ACME.LearningCenter_Platform.IAM.Interfaces.ACL.Services;

public interface IIamContextFacade
{
    Task<int> CreateUser(string username, string password);

    Task<int> FetchUserIdByUsername(string username);

    Task<string> FetchUsernameByUserId(int userId);
}