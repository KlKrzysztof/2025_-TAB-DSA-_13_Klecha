using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/outfitting")]
public class VehicleOutfittingController(IVehicleOutfittingQuery query) : ControllerBase
{
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
    public async Task<IActionResult> CreateVehicleOutfittingAsync(Vehicleoutfitting model)
    {
        try
        {
            await query.CreateVehicleOutfittingAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateVehicleOutfittingAsync(Vehicleoutfitting model)
    {
        try
        {
            await query.UpdateVehicleOutfittingAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
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
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
