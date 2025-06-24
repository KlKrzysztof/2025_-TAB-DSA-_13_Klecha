using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.User;
using System.Formats.Asn1;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<UserModel> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

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

    [HttpGet("get/login/{login}")]
    public async Task<IActionResult> GetUserByLoginAsync(string login)
    {
        var res = await query.GetUserByLoginAsync(login);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateUserAsync(UserModel model)
    {
        try
        {
            await query.CreateUserAsync(model);
            return Ok();
        }
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("put", model, ex);
            return StatusCode(500, msg);
            throw;
        }
    }

    [HttpPatch("patch/lastlogin/id/{id}")]
    public async Task<IActionResult> PatchLastLogin(int id)
    {
        try
        {
            await query.PatchLastLogin(id);
            return Ok();
        }
        catch (Exception)
        {
            throw;
        }
    }


    [HttpGet("authenticate")]
    public async Task<IActionResult> Authenticate(
        [FromHeader(Name = "login")]string login, 
        [FromHeader(Name = "password")] string password)
    {
        var res = await query.Authenticate(login, password);
        return Ok(res);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateUserAsync(UserModel model)
    {
        try
        {
            await query.UpdateUserAsync(model);
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
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        try
        {
            await query.DeleteUserAsync(id);
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