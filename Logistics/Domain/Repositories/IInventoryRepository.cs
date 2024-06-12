using catchupcomplete.Shared.Domain.Repositories;
using pc2_202302.Logistics.Domain.Model.Aggregates;

namespace pc2_202302.Logistics.Domain.Repositories;

public interface IInventoryRepository : IBaseRepository<Inventory>
{
    Task<Inventory> GetInventoryAsync(int id);
    Task<Inventory> GetInventoryByProductIdAndWarehouseIdAsync(int productId, int warehouseId);
    //todo volver, puede que necesite algo mas en especial para llamar
}