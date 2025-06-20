using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Manufacturer;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/vehicle/manufacturer")]
public class ManufacturerController(IManufacturerQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<ManufacturerModel> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

    [HttpGet("all")]
    public async Task<IActionResult> GetManufacturersAsync()
    {
        var res = await query.GetManufacturersAsync();
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("id/{id:int}")]
    public async Task<IActionResult> GetManufacturerByIdASync(int id)
    {
        var res = await query.GetManufacturerByIdAsync(id);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetManufacturerByNameAsync(string name)
    {
        var res = await query.GetManufacturerByNameAsync(name);
        return res != null ? Ok(res) : BadRequest();
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateManufacturerAsync(ManufacturerModel model)
    {
        try
        {
            await query.CreateManufacturerAsync(model);
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
    public async Task<IActionResult> UpdateManufacturerAsync(ManufacturerModel model)
    {
        try
        {
            await query.UpdateManufacturerAsync(model);
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
    public async Task<IActionResult> DeleteManufacturerAsync(int id)
    {
        try
        {
            await query.DeleteManufacturerAsync(id);
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