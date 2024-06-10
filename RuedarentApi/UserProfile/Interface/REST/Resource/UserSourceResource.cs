namespace RuedarentApi.UserProfile.Interface.REST.Resource;

public record UserSourceResource(int Id, string Name, string Surname, string Email, string Password, string Phone, string Address, string City, string Country, int UserId, int Dni);