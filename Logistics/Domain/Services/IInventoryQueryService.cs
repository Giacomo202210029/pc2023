using pc2_202302.Logistics.Domain.Model.Aggregates;
using pc2_202302.Logistics.Domain.Model.Queries;

namespace pc2_202302.Logistics.Domain.Services;

public interface IInventoryQueryService
{
    Task<Inventory> Handle(GetInventoryByProductIdAndWarehouseIdQuery query); 
    Task<Inventory> Hanlde(GetInventoryByIdQuery query);
}