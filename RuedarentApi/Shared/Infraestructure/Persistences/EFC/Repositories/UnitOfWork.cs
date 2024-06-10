using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;

namespace RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _context;

    public UnitOfWork(AppDBContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    } 
}