using catchupcomplete.Shared.Domain.Repositories;
using pc2_202302.Logistics.Domain.Model.Aggregates;
using pc2_202302.Logistics.Domain.Model.Commands;
using pc2_202302.Logistics.Domain.Repositories;
using pc2_202302.Logistics.Domain.Services;

namespace pc2_202302.Logistics.Application.Internal.CommandServices;

public class InventoryCommandService: IInventoryCommandService
{
    IInventoryRepository _inventoryRepository;
    IUnitOfWork _unitOfWork; //11

    public InventoryCommandService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
    {
        _inventoryRepository = inventoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Inventory> Handle(CreateInventoryCommand command)
    {
        // Check if an inventory with the same ProductId and WarehouseId already exists
        var existingInventory = await _inventoryRepository.GetInventoryByProductIdAndWarehouseIdAsync(command.ProductId, command.WarehouseId);
        if(existingInventory != null)
            throw new Exception("Inventory with the same ProductId and WarehouseId already exists");

        // Check if MinimumStock is greater than or equal to 1
        if(command.MinimumStock < 1)
            throw new Exception("MinimumStock must be greater than or equal to 1");

        // Check if CurrentStock is not less than MinimumStock
        if(command.CurrentStock < command.MinimumStock)
            throw new Exception("CurrentStock cannot be less than MinimumStock");

        var newInventory = new Inventory(command);
        await _inventoryRepository.AddAsync(newInventory);
        await _unitOfWork.CompleteAsync();
        return newInventory;
    }
}