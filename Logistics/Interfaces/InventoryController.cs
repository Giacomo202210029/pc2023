using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using pc2_202302.Logistics.Domain.Model.Queries;
using pc2_202302.Logistics.Domain.Services;
using pc2_202302.Logistics.Interfaces.REST.Resources;
using pc2_202302.Logistics.Interfaces.REST.Transform;

namespace pc2_202302.Logistics.Interfaces;


[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class InventoryController : ControllerBase
{
    IInventoryCommandService _inventoryCommandService;
    IInventoryQueryService _inventoryQueryService;
    
    public InventoryController(IInventoryCommandService inventoryCommandService, IInventoryQueryService inventoryQueryService)
    {
        _inventoryCommandService = inventoryCommandService;
        _inventoryQueryService = inventoryQueryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateInventory([FromBody] CreateInventoryResource resource)
    {
        var createInventoryCommand = CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _inventoryCommandService.Handle(createInventoryCommand);
        return CreatedAtAction(nameof(GetInventoryByIdQuery), new { id = result.Id },
            InventoryResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetInventoryByIdQuery(int id)
    {
        var query = new GetInventoryByIdQuery(id);
        var result = await _inventoryQueryService.Hanlde(query);
        return Ok(InventoryResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet]
    public async Task<ActionResult> GetInventoryByProductIdAndWarehouseIdQuery(int productId, int warehouseId)
    {
        var query = new GetInventoryByProductIdAndWarehouseIdQuery(productId, warehouseId);
        var result = await _inventoryQueryService.Handle(query);
        return Ok(InventoryResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}