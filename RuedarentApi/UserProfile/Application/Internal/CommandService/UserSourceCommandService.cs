using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.UserProfile.Domain.Model.Aggregates;
using RuedarentApi.UserProfile.Domain.Model.Commands;
using RuedarentApi.UserProfile.Domain.Repositories;
using RuedarentApi.UserProfile.Domain.Services;

namespace RuedarentApi.UserProfile.Application.Internal.CommandService;

public class UserSourceCommandService(IUserSourceRepository userSourceRepository
, IUnitOfWork unitOfWork) : IUserSourceCommandService
{
    public async Task<UserSource> Handle(CreateUserSourceCommand command)
    {
        var favoriteSource = await
            userSourceRepository.FindByUserDNIAsync(command.DNI);
        if (favoriteSource != null)
            throw new Exception("Favorite source with this DNI already exists");
        favoriteSource = new UserSource(command);
        await userSourceRepository.AddAsync(favoriteSource);
        await unitOfWork.CompleteAsync();
        return favoriteSource;
        
    }
}