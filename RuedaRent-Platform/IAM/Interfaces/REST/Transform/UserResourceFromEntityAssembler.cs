using ACME.LearningCenter_Platform.IAM.Interfaces.Resources;

namespace ACME.LearningCenter_Platform.IAM.Interfaces.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}