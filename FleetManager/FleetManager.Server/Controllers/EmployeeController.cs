using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/employee")]
public class EmployeeController(IEmployeeQuery query) : ControllerBase
{


    [HttpGet("get/all")]
    public async Task<IActionResult> GetEmployeesAsync()
    {
        var res = await query.GetEmployeesAsync();
        return Ok(res);
    }

    [HttpGet("get/id/{id:int}")]
    public async Task<IActionResult> GetEmployeeByIdAsync(int id)
    {
        var res = await query.GetEmployeeByIdAsync(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateEmployee(EmployeeModel model)
    {
        try
        {
            await query.CreateEmployee(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateEmployee(EmployeeModel model)
    {
        try
        {
            await query.UpdateEmployee(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("delet/{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            await query.DeleteEmployee(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}