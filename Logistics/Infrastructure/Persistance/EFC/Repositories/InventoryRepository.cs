using catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using pc2_202302.Logistics.Domain.Model.Aggregates;
using pc2_202302.Logistics.Domain.Repositories;
using pc2_202302.Logistics.Domain.Services;

namespace pc2_202302.Logistics.Infrastructure.Persistance.EFC.Repositories;

public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Inventory> GetInventoryAsync(int id)
    {
        return await Context.Set<Inventory>().Where(f=>f.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Inventory> GetInventoryByProductIdAndWarehouseIdAsync(int productId, int warehouseId)
    {
        return await Context.Set<Inventory>().Where(f=>f.ProductId == productId && f.WarehouseId == warehouseId).FirstOrDefaultAsync();
    }
}