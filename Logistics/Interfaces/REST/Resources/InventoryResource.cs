namespace pc2_202302.Logistics.Interfaces.REST.Resources;

public record InventoryResource(int Id, int ProductId, int WarehouseId, int MinimumStock, int CurrentStock, DateTime CreatedAt);