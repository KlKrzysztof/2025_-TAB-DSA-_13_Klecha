using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Caretake;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/caretake")]
public class CaretakeController(ICaretakeQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<CaretakeModel> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

    [HttpGet("get/all")]
    public async Task<IActionResult> GetCaretakesAsync()
    {
        var res = await query.GetCaretakesAsync();
        return Ok(res);
    }

    [HttpGet("get/id/{id}")]
    public async Task<IActionResult> GetCaretakeByIdAsync(int id)
    {
        var res = await query.GetCaretakeByIdAsync(id);
        return Ok(res);
    }

    [HttpGet("get/vehicle/id/{id}")]
    public async Task<IActionResult> GetCaretakeByVehicleId(int id)
    {
        var res = await query.GetCaretakeByVehicleIdAsync(id);
        return Ok(res);
    }
    
    [HttpGet("get/employee/id/{id}")]
    public async Task<IActionResult> GetCaretakeByEmployeeId(int id)
    {
        var res = await query.GetCaretakeByEmployeeIdAsync(id);
        return Ok(res);
    }

    [HttpGet("get/details/id/{id:int}")]
    public async Task<IActionResult> GetCaretakeDetailsByIdAsync(int id)
    {
        var res = await query.GetCaretakeDetailsByIdAsync(id);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("get/finished")]
    public async Task<IActionResult> GetFinishedCaretakesAsync()
    {
        var res = await query.GetFinishedCaretakesAsync();
        return Ok(res);
    }

    [HttpPatch("patch/employee/id/{employeeId}/vehicle/id/{vehicleId:int}")]
    public async Task<IActionResult> PatchVehicleCaretaker(uint employeeId, int vehicleId)
    {
        try
        {
            await query.PatchVehicleCaretakerAsync(employeeId, vehicleId);
            return Ok();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateCaretakeAsync(CaretakeModel model)
    {
        try
        {
            await query.CreateCaretakeAsync(model);
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
    public async Task<IActionResult> UpdateCaretakeAsync(CaretakeModel model)
    {
        try
        {
            await query.UpdateCaretakeAsync(model);
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
    public async Task<IActionResult> DeleteCaretakeAsync(int id)
    {
        try
        {
            await query.DeleteCaretakeAsync(id);
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
