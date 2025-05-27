using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/operationalactivities")]
public class OperationalActivitiesController(IOperationalActivityQuery query) : ControllerBase
{
    [HttpGet("get/all")]
    public async Task<IActionResult> GetOperationalActivitiesAsync()
    {
        var res = await query.GetOperationalActivitiesAsync();
        return Ok(res);
    }

    [HttpGet("get/vehicle/id/{id:int}")]
    public async Task<IActionResult> GetOperationalActivitiesForVehicle(int id)
    {
        var res = await query.GetOperationalActivitiesForVehicle(id);
        return Ok(res);
    }

    [HttpGet("get/id/{id:int}")]
    public async Task<IActionResult> GetOperationalActivityByIdAsync(int id)
    {
        var res = await query.GetOperationalActivityByIdAsync(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateOperationalActivityAsync(Operationalactivity model)
    {
        try
        {
            await query.CreateOperationalActivityAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateOperationalActivityAsync(Operationalactivity model)
    {
        try
        {
            await query.UpdateOperationalActivityAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteOperationalActivityAsync(int id)
    {
        try
        {
            await query.DeleteOperationalActivityAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }
}