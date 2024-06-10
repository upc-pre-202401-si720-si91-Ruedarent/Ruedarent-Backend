using RuedarentApi.UserProfile.Domain.Model.Aggregates;
using RuedarentApi.UserProfile.Interface.REST.Resource;

namespace RuedarentApi.UserProfile.Interface.REST.Transform;

public static class UserSourceResourceFromEntityAssembler
{
    public static UserSourceResource toResourceFromEntity(UserSource entity)=>
        new UserSourceResource(entity.Id, entity.Name, entity.Surname, entity.Email, entity.Password, entity.Phone, entity.Address, entity.City, entity.Country, entity.UserId, entity.Dni);
}