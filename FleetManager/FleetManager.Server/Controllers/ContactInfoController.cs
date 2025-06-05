using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.ContactInfo;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/contact")]
public class ContactInfoController(IContactInfoQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<ContactInfo> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

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
    public async Task<IActionResult> CreateContactInfoAsync(ContactInfo model)
    {
        try
        {
            await query.CreateContactInfoAsync(model);
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
    public async Task<IActionResult> UpdateContactInfoAsync(ContactInfo model)
    {
        try
        {
            await query.UpdateContactInfoAsync(model);
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
    public async Task<IActionResult> DeleteContactInfoAsync(int id)
    {
        try
        {
            await query.DeleteContactInfoAsync(id);
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