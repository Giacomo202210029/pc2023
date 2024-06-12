using pc2_202302.Logistics.Domain.Model.Commands;

namespace pc2_202302.Logistics.Domain.Model.Aggregates;

public class Inventory
{
    public int Id { get; private set; }
    public int ProductId { get;  set; }
    public int MinimumStock { get;  set; }
    public int WarehouseId { get;  set; }
    public int CurrentStock { get;  set; }
    public DateTime CreatedAt { get;  set; }

    protected Inventory()
    {
        ProductId = 0; 
        MinimumStock = 0;
        WarehouseId = 0;
        CurrentStock = 0;
    }
    
    public Inventory(CreateInventoryCommand command)
    {
        this.ProductId = command.ProductId;
        this.WarehouseId = command.WarehouseId;
        this.MinimumStock = command.MinimumStock;
        this.CurrentStock = command.CurrentStock;
        this.CreatedAt = DateTime.Now; //todo un requisito hecho uwuuuuuuu
    }
}