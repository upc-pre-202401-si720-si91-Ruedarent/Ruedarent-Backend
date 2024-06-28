using ACME.LearningCenter_Platform.IAM.Interfaces.Resources;

namespace ACME.LearningCenter_Platform.IAM.Interfaces.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}