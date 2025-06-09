using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/purpose")]
public class VehiclePurposeController(IVehiclePurposeQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<VehiclePurpose> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

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
    public async Task<IActionResult> CreateVehiclePurposeAsync(VehiclePurpose model)
    {
        try
        {
            await query.CreateVehiclePurposeAsync(model);
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
    public async Task<IActionResult> UpdateVehiclePurposeAsync(VehiclePurpose model)
    {
        try
        {
            await query.UpdateVehiclePurposeAsync(model);
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
    public async Task<IActionResult> DeleteVehiclePurposeAsync(int id)
    {
        try
        {
            await query.DeleteVehiclePurposeAsync(id);
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
