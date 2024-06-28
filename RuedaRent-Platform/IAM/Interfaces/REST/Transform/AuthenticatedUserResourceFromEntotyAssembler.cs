using ACME.LearningCenter_Platform.IAM.Interfaces.Resources;

namespace ACME.LearningCenter_Platform.IAM.Interfaces.Transform;

public class AuthenticatedUserResourceFromEntotyAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}