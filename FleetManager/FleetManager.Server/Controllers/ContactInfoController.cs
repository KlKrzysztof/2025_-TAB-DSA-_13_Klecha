using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/contact")]
public class ContactInfoController(IContactInfoQuery query) : ControllerBase
{
    [HttpGet("get/all")]
    public async Task<IActionResult> GetContactInfosAsync()
    {
        var res = await query.GetContactInfosAsync();
        return Ok(res);
    }

    [HttpGet("get/id/{id}")]
    public async Task<IActionResult> GetContactInfoByIdAscyn(int id)
    {
        var res = await query.GetContactInfoByIdAsync(id);
        return Ok(res);
    }

    [HttpGet("get/employee/id/{id}")]
    public async Task<IActionResult> GetEmployeesContactInfoAsync(int id)
    {
        var res = await query.GetEmployeesContactInfoAsync(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateContactInfoAsync(Contactinfo model)
    {
        try
        {
            await query.CreateContactInfoAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateContactInfoAsync(Contactinfo model)
    {
        try
        {
            await query.UpdateContactInfoAsync(model);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("delete/id/{id:int}")]
    public async Task<IActionResult> DeleteContactInfoAsync(int id)
    {
        try
        {
            await query.DeleteContactInfoAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}