namespace RuedarentApi.UserProfile.Domain.Model.Commands;

public record CreateUserSourceCommand(string Name, string Surname, string Email, string Password, string Phone, string Address, string City, string Country, int UserId, int DNI);