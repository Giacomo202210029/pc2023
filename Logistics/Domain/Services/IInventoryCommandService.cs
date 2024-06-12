using pc2_202302.Logistics.Domain.Model.Aggregates;
using pc2_202302.Logistics.Domain.Model.Commands;

namespace pc2_202302.Logistics.Domain.Services;

public interface IInventoryCommandService
{
    Task<Inventory> Handle(CreateInventoryCommand command); 
}