using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/model")]
public class VehicleModelController(IVehicleModelQuery query) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetVehicleModelsAsync()
    {
        var res = await query.GetVehicleModelsAsync();
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("id/{id:int}")]
    public async Task<IActionResult> GetVehicleModelByIdAsync(int id)
    {
        var res = await query.GetVehicleModelByIdAsync(id);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateVehicleModelAsync(VehicleModel model)
    {
        try
        {
            await query.CreateVehicleModelAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateVehicleModelAsync(VehicleModel model)
    {
        try
        {
            await query.UpdateVehicleModelAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteVehicleModelAsync(int id)
    {
        try
        {
            await query.DeleteVehicleModelAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
