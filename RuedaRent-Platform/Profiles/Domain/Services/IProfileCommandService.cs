namespace ACME.LearningCenter_Platform.Profiles;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}