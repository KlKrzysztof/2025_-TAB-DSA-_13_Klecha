﻿using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/vehicle")]
public class VehicleController(IVehicleQuery query) : ControllerBase
{
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

    [HttpGet("plate/{number}")]
    public async Task<IActionResult> GetVehicleByPlateNumber(string number)
    {
        var res = await query.GetVehicleByPlateNumber(number);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("details/id/{id}")]
    public async Task<IActionResult> GetVehicleDetailsByIdAsync(int id)
    {
        var res = await query.GetVehicleDetailsByIdAsync(id);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("vehicle/caretake/id/{id:int}")]
    public async Task<IActionResult> GetVehicleAndCaretakerByIdAsync(int id)
    {
        var res = await query.GetVehicleAndCaretakerByIdAsync(id);
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