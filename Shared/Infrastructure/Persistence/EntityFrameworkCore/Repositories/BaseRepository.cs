using catchupcomplete.Shared.Domain.Repositories;
using catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    //para interactuar con la base de datos necesita: 
    protected readonly AppDbContext Context;
    
    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }
    
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity); //agregar a la base de datos
    }

    public async Task<TEntity> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}