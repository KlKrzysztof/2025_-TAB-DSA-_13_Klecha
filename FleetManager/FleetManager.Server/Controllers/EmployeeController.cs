using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/employees")]
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

}
