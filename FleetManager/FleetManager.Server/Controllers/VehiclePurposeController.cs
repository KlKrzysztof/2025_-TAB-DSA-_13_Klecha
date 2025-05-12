using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/purpose")]
public class VehiclePurposeController(IVehiclePurposeQuery query) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetVehiclePurposesAsync()
    {
        var res = await query.GetVehiclePurposesAsync();
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("id/{id:int}")]
    public async Task<IActionResult> GetVehiclePurposeByIdAsync(int id)
    {
        var res = await query.GetVehiclePurposeByIdAsync(id);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetVehiclePurposeByNameAsync(string name)
    {
        var res = await query.GetVehiclePurposeByNameAsync(name);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateVehiclePurposeAsync(Vehiclepurpose model)
    {
        try
        {
            await query.CreateVehiclePurposeAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateVehiclePurposeAsync(Vehiclepurpose model)
    {
        try
        {
            await query.UpdateVehiclePurposeAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteVehiclePurposeAsync(int id)
    {
        try
        {
            await query.DeleteVehiclePurposeAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
