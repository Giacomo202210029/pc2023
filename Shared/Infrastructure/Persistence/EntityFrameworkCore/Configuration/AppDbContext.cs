using catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using pc2_202302.Logistics.Domain.Model.Aggregates;

namespace catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor(); 
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Inventory>().ToTable("FavoriteSource"); 
        builder.Entity<Inventory>().HasKey(f =>f.Id);
        builder.Entity<Inventory>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Inventory>().Property(f => f.CurrentStock).IsRequired();
        builder.Entity<Inventory>().Property(f => f.ProductId).IsRequired();
        builder.Entity<Inventory>().Property(f => f.MinimumStock).IsRequired();
        builder.Entity<Inventory>().Property(f => f.WarehouseId).IsRequired();
        builder.Entity<Inventory>().Property(f => f.CreatedAt).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}