using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserQuery query) : ControllerBase
{
    [HttpGet("get/all")]
    public async Task<IActionResult> GetUserAsync()
    {
        var res = await query.GetUsersAsync();
        return Ok(res);
    }

    [HttpGet("get/id/{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var res = await query.GetUserByIdAsync(id);
        return Ok(res);
    }

    [HttpGet("get/employee/id/{id}")]
    public async Task<IActionResult> GetUserByEmployeeIdAsync(int id)
    {
        var res = await query.GetUserByEmployeeIdAsync(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateUserAsync(User model)
    {
        try
        {
            await query.CreateUserAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateUserAsync(User model)
    {
        try
        {
            await query.UpdateUserAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        try
        {
            await query.DeleteUserAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}