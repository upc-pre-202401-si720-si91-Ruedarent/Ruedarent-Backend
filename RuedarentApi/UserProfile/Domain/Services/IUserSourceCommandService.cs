using RuedarentApi.UserProfile.Domain.Model.Aggregates;
using RuedarentApi.UserProfile.Domain.Model.Commands;

namespace RuedarentApi.UserProfile.Domain.Services;

public interface IUserSourceCommandService
{
    Task<UserSource> Handle(CreateUserSourceCommand command);
}