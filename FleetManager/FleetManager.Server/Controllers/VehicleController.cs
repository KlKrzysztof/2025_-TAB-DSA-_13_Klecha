using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/vehicle")]
public class VehicleController(IVehicleQuery query) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetVehiclesAsync()
    {
        var res = await query.GetVehiclesAsync();
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("id/{id:int}")]
    public async Task<IActionResult> GetVehicleByIdAsync(int id)
    {
        var res = await query.GetVehicleByIdAsync(id);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("vin/{vin}")]
    public async Task<IActionResult> GetVehicleByVinAsync(string vin)
    {
        var res = await query.GetVehicleByVinAsync(vin);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("plate/{platenumber}")]
    public async Task<IActionResult> GetVehicleByPlateNumber(string plateNumber)
    {
        var res = await query.GetVehicleByPlateNumber(plateNumber);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateVehicleAsync(Vehicle model)
    {
        try
        {
            await query.CreateVehicleAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateVehicleAsync(Vehicle model)
    {
        try
        {
            await query.UpdateVehicleAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteVehicleAsync(int id)
    {
        try
        {
            await query.DeleteVehicleAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}