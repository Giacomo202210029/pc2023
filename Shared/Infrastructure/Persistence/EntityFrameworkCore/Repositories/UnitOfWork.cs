using catchupcomplete.Shared.Domain.Repositories;
using catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

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