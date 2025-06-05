using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Address;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/address")]
public class AddressController(IAddressQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<Address> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

    [HttpGet("get/all")]
    public async Task<IActionResult> GetAddressesAsync()
    {
        var res = await query.GetAddressesAsync();
        return Ok(res);
    }

    [HttpGet("get/id/{id:int}")]
    public async Task<IActionResult> GetAddressByIdAsync(int id)
    {
        var res = await query.GetAddressByIdAsync(id);
        return Ok(res);
    }

    [HttpGet("get/employee/id/{id:int}")]
    public async Task<IActionResult> GetAddressByEmployeeIdAsync(int id)
    {
        var res = await query.GetAddressesByEmployeeIdAsync(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateAddressAsync(Address model)
    {
        try
        {
            await query.CreateAddressAsync(model);
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
    public async Task<IActionResult> UpdateAddressAsync(Address model)
    {
        try
        {
            await query.UpdateAddressAsync(model);
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
    public async Task<IActionResult> DeleteAddressAsync(int id)
    {
        try
        {
            await query.DeleteAddressAsync(id);
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