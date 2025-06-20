using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Refuel;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/refuel")]
public class RefuelController(IRefuelQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<RefuelModel> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

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
    public async Task<IActionResult> CreateRefuelAsync(RefuelModel model)
    {
        try
        {
            await query.CreateRefuelAsync(model);
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
    public async Task<IActionResult> UpdateRefuelAsync(RefuelModel model)
    {
        try
        {
            await query.UpdateRefuelAsync(model);
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
    public async Task<IActionResult> DeleteRefuelAsync(int id)
    {
        try
        {
            await query.DeleteRefuelAsync(id);
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
