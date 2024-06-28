using ACME.LearningCenter_Platform.IAM.Interfaces.Resources;

namespace ACME.LearningCenter_Platform.IAM.Interfaces.Transform;

public class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}