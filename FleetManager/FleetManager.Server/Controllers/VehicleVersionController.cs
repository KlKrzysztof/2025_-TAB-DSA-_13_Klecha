using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/version")]
public class VehicleVersionController(IVehicleVersionQuery query) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetVehicleVersionsAsync()
    {
        var res = await query.GetVehicleVersionsAsync();
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("id/{id:int}")]
    public async Task<IActionResult> GetVehicleVersionByIdAsync(int id)
    {
        var res = await query.GetVehicleVersionByIdAsync(id);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateVehicleVersionAsync(Vehicleversion model)
    {
        try
        {
            await query.CreateVehicleVersionAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateVehicleVersionAsync(Vehicleversion model)
    {
        try
        {
            await query.UpdateVehicleVersionAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteVehicleVersionAsync(int id)
    {
        try
        {
            await query.DeleteVehicleVersionAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
