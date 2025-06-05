using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/vehicle")]
public class VehicleController(IVehicleQuery query) : ControllerBase
{
    //piotrek service begin
    [HttpGet("inService")]
    public async Task<IActionResult> GetVehiclesInServiceAsync()
    {
        var res = await query.GetVehiclesInServiceAsync();
        return res != null ? Ok(res) : NotFound();
    }

    [HttpGet("notInService")]
    public async Task<IActionResult> GetVehiclesNotInServiceAsync()
    {
        var res = await query.GetVehiclesNotInServiceAsync();
        return res != null ? Ok(res) : NotFound();
    }

    [HttpPost("sendToService/{id:int}")]
    public async Task<IActionResult> UpdateSendToService(int id)
    {
        try
        {
            await query.UpdateSendToService(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("returnFromService/{id:int}")]
    public async Task<IActionResult> UpdateReturnFromService(int id)
    {
        try
        {
            await query.UpdateReturnFromService(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    //piotrek service end

    private readonly ErrorStringsCreator<Vehicle> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

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
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("put", model, ex);
            return StatusCode(500, msg);
            throw;
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
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("post", model, ex);
            return StatusCode(500, msg);
            throw;
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
        catch (Exception ex)
        {
            var msg = exCreatorInt.ConstructErrorMessage("delete", id, ex);
            return StatusCode(500, msg);
            throw;
        }
    }
}