namespace pc2_202302.Logistics.Domain.Model.Commands;

public record CreateInventoryCommand(int ProductId, int WarehouseId, int MinimumStock, int CurrentStock);