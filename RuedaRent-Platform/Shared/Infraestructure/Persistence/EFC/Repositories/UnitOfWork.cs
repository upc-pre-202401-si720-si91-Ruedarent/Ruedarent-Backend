using ACME.LearningCenter_Platform.Shared.Domain.Repositories;
using ACME.LearningCenter_Platform.Shared.Interfaces.ASP.Configuration;

namespace ACME.LearningCenter_Platform.Shared.Infraestructure.Persistence.EFC.Repositories;

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