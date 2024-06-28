namespace ACME.LearningCenter_Platform.Profiles;

public record EmailAddress(string Address)
{
    public EmailAddress() : this(string.Empty)
    {
    }
}