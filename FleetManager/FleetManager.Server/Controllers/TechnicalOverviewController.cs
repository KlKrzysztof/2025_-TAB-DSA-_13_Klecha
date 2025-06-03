using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.TechnicalOverview;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/technicaloverview")]
public class TechnicalOverviewController(ITechnicalOverviewQuery query) : ControllerBase
{
    [HttpGet("get/all")]
    public async Task<IActionResult> GetTechnicalOverviewsAsync()
    {
        var res = await query.GetTechnicalOverviewsAsync();
        return Ok(res);
    }

    [HttpGet("get/vehicle/id/{id:int}")]
    public async Task<IActionResult> GetTechnicalOverviewsForVehicleAsync(int id)
    {
        var res = await query.GetTechnicalOverviewsForVehicleAsync(id);
        return Ok(res);
    }

    [HttpGet("get/id/{id:int}")]
    public async Task<IActionResult> GetTechnicalOverviewByIdAsync(int id)
    {
        var res = await query.GetTechnicalOverviewByIdAsync(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateTechnicalOverviewAsync(TechnicalOverview model)
    {
        try
        {
            await query.CreateTechnicalOverviewAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateTechnicalOverviewAsync(TechnicalOverview model)
    {
        try
        {
            await query.UpdateTechnicalOverviewAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteTechnicalOverviewAsync(int id)
    {
        try
        {
            await query.DeleteTechnicalOverviewAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
            throw;
        }
    }
}