using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/version")]
public class VehicleVersionController(IVehicleVersionQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<VehicleVersion> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

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
    public async Task<IActionResult> CreateVehicleVersionAsync(VehicleVersion model)
    {
        try
        {
            await query.CreateVehicleVersionAsync(model);
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
    public async Task<IActionResult> UpdateVehicleVersionAsync(VehicleVersion model)
    {
        try
        {
            await query.UpdateVehicleVersionAsync(model);
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
    public async Task<IActionResult> DeleteVehicleVersionAsync(int id)
    {
        try
        {
            await query.DeleteVehicleVersionAsync(id);
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
