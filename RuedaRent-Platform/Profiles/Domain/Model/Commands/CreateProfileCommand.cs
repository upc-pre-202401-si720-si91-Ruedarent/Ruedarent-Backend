namespace ACME.LearningCenter_Platform.Profiles;

public record CreateProfileCommand(
    string firstName,
    string lastName,
    string email,
    string street,
    string number,
    string city,
    string postalCode,
    string country,
    string phoneNumber,
    string vehicleName);