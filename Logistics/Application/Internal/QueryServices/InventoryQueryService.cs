using pc2_202302.Logistics.Domain.Model.Aggregates;
using pc2_202302.Logistics.Domain.Model.Queries;
using pc2_202302.Logistics.Domain.Repositories;
using pc2_202302.Logistics.Domain.Services;

namespace pc2_202302.Logistics.Application.Internal.QueryServices;

public class InventoryQueryService : IInventoryQueryService
{
    IInventoryRepository _inventoryRepository;

    public InventoryQueryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<Inventory> Handle(GetInventoryByProductIdAndWarehouseIdQuery query)
    {
        return await _inventoryRepository.GetInventoryByProductIdAndWarehouseIdAsync(query.ProductId, query.WarehouseId);
    }

    public async Task<Inventory> Hanlde(GetInventoryByIdQuery query)
    {
        return await _inventoryRepository.GetInventoryAsync(query.Id);
    }
}