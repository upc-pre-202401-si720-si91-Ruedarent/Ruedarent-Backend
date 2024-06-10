using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;

namespace RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    } 
}