using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Caretake;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/caretake")]
public class CaretakeController(ICaretakeQuery query) : ControllerBase
{
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
        var res = await query.GetCaretakeByVehicleId(id);
        return Ok(res);
    }
    
    [HttpGet("get/employee/id/{id}")]
    public async Task<IActionResult> GetCaretakeByEmployeeId(int id)
    {
        var res = await query.GetCaretakeByEmployeeId(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateCaretakeAsync(Caretake model)
    {
        try
        {
            await query.CreateCaretakeAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateCaretakeAsync(Caretake model)
    {
        try
        {
            await query.UpdateCaretakeAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
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
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
