using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.OperationalActivity;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/operationalactivity")]
public class OperationalActivitiesController(IOperationalActivityQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<Operationalactivity> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

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
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("put", model, ex);
            return StatusCode(500, msg);
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
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("post", model, ex);
            return StatusCode(500, msg);
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
        catch (Exception ex)
        {
            var msg = exCreatorInt.ConstructErrorMessage("delete", id, ex);
            return StatusCode(500, msg);
            throw;
        }
    }
}