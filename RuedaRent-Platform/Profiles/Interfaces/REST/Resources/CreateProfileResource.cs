namespace ACME.LearningCenter_Platform.Profiles;

public record CreateProfileResource(
    string FirstName,
    string LastName,
    string Email,
    string Street,
    string Number,
    string City,
    string PostalCode,
    string Country,
    string PhoneNumber,
    string vehicleName);