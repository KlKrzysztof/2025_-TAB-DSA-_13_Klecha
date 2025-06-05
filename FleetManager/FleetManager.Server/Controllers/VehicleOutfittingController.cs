using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/outfitting")]
public class VehicleOutfittingController(IVehicleOutfittingQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<VehicleOutfitting> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

    [HttpGet("all")]
    public async Task<IActionResult> GetVehicleoutfittingsAsync()
    {
        var res = await query.GetVehicleoutfittingsAsync();
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("id/{id:int}")]
    public async Task<IActionResult> GetVehicleoutfittingByIdAsync(int id)
    {
        var res = await query.GetVehicleoutfittingByIdAsync(id);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateVehicleOutfittingAsync(VehicleOutfitting model)
    {
        try
        {
            await query.CreateVehicleOutfittingAsync(model);
            return Ok();
        }
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("put", model, ex);
            return StatusCode(500, msg);
            throw;
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateVehicleOutfittingAsync(VehicleOutfitting model)
    {
        try
        {
            await query.UpdateVehicleOutfittingAsync(model);
            return Ok();
        }
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("post", model, ex);
            return StatusCode(500, msg);
            throw;
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteVehicleOutfittingAsync(int id)
    {
        try
        {
            await query.DeleteVehicleOutfittingAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            var msg = exCreatorInt.ConstructErrorMessage("delete", id, ex);
            return StatusCode(500, msg);
            throw;
        }
    }
}
