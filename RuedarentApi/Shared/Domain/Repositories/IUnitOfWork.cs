using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;

namespace RuedarentApi.Shared.Domain.Repositories;

public interface IUnitOfWork
{

    Task CompleteAsync();
    
}