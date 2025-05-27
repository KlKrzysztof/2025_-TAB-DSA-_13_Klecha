using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/refuel")]
public class RefuelController(IRefuelQuery query) : ControllerBase
{
    [HttpGet("get/all")]
    public async Task<IActionResult> GetRefuelsAsync()
    {
        var res = await query.GetRefuelsAsync();
        return Ok(res);
    }

    [HttpGet("get/vehicle/id/{id:int}")]
    public async Task<IActionResult> GetRefuelsForVehicleAsync(int id)
    {
        var res = await query.GetRefuelsForVehicleAsync(id);
        return Ok(res);
    }

    [HttpGet("get/id/{id:int}")]
    public async Task<IActionResult> GetRefuelByIdAsync(int id)
    {
        var res = await query.GetRefuelByIdAsync(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateRefuelAsync(Refuel model)
    {
        try
        {
            await query.CreateRefuelAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateRefuelAsync(Refuel model)
    {
        try
        {
            await query.UpdateRefuelAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteRefuelAsync(int id)
    {
        try
        {
            await query.DeleteRefuelAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }
}
