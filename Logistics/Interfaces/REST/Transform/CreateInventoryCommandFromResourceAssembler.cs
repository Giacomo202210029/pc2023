using pc2_202302.Logistics.Domain.Model.Commands;
using pc2_202302.Logistics.Interfaces.REST.Resources;

namespace pc2_202302.Logistics.Interfaces.REST.Transform;

public class CreateInventoryCommandFromResourceAssembler
{
    public static CreateInventoryCommand ToCommandFromResource(CreateInventoryResource resource)
    {
        return new CreateInventoryCommand(resource.ProductId, resource.WarehouseId, resource.MinimumStock, resource.CurrentStock);
    }
}