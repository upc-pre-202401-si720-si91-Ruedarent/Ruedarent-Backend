using RuedarentApi.UserProfile.Domain.Model.Commands;
using RuedarentApi.UserProfile.Interface.REST.Resource;

namespace RuedarentApi.UserProfile.Interface.REST.Transform;

public class CreateUserSourceCommandFromResourceAssembler
{
    public static CreateUserSourceCommand
        ToCommandFromResource(CreateUserSourceResource resource) =>
        new CreateUserSourceCommand(resource.Name, resource.Surname, resource.Email, resource.Password, resource.Phone, resource.Address, resource.City, resource.Country, resource.UserId, resource.Dni);
}