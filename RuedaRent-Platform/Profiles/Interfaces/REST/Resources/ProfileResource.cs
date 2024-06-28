namespace ACME.LearningCenter_Platform.Profiles;

public record ProfileResource(
    int Id,
    string FullName,
    string Email,
    string StreetAddress,
    string phoneNumber,
    string vehicleName);