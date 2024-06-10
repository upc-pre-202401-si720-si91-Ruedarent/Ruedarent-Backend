using RuedarentApi.UserProfile.Domain.Model.Commands;

namespace RuedarentApi.UserProfile.Domain.Model.Aggregates;

public class UserSource
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string Phone { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string Country { get; set; }
    
    public int UserId { get; set; }
    
    public int Dni { get; set; }

    protected UserSource()
    {
        this.Name = string.Empty;
        this.Surname = string.Empty;
        this.Email = string.Empty;
        this.Password = string.Empty;
        this.Phone = string.Empty;
        this.Address = string.Empty;
        this.City = string.Empty;
        this.Country = string.Empty;
        this.UserId = 0;
        this.Dni = 0;
    }
    
    public UserSource(CreateUserSourceCommand command)
    {
        this.Name = command.Name;
        this.Surname = command.Surname;
        this.Email = command.Email;
        this.Password = command.Password;
        this.Phone = command.Phone;
        this.Address = command.Address;
        this.City = command.City;
        this.Country = command.Country;
        this.UserId = command.UserId;
        this.Dni = command.DNI;
    }
    
    
    
}