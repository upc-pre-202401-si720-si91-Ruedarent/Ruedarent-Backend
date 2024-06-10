namespace RuedarentApi.UserProfile.Interface.REST.Resource;

public record CreateUserSourceResource(string Name, string Surname, string Email, string Password, string Phone, string Address, string City, string Country, int UserId, int Dni);