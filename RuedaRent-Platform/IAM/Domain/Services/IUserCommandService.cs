namespace ACME.LearningCenter_Platform.IAM;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);

    Task Handle(SignUpCommand command);
}