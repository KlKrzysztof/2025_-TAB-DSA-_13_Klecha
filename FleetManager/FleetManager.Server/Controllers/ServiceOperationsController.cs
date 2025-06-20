using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.ServiceOperation;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/serviceoperation")]
public class ServiceOperationsController(IServiceOperationsQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<ServiceOperationModel> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

    [HttpGet("get/all")]
    public async Task<IActionResult> GetServiceOperationsAsync()
    {
        var res = await query.GetServiceOperationsAsync();
        return Ok(res);
    }

    [HttpGet("get/vehicle/id/{id:int}")]
    public async Task<IActionResult> GetServiceOperationsForVehicleAsync(int id)
    {
        var res = await query.GetServiceOperationsForVehicleAsync(id);
        return Ok(res);
    }

    [HttpGet("get/id/{id:int}")]
    public async Task<IActionResult> GetServiceOperationByIdAsync(int id)
    {
        var res = await query.GetServiceOperationByIdAsync(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateServiceOperationAsync(ServiceOperationModel model)
    {
        try
        {
            await query.CreateServiceOperationAsync(model);
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
    public async Task<IActionResult> UpdateServiceOperationAsync(ServiceOperationModel model)
    {
        try
        {
            await query.UpdateServiceOperationAsync(model);
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
    public async Task<IActionResult> DeleteServiceOperationsAsync(int id)
    {
        try
        {
            await query.DeleteServiceOperationsAsync(id);
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
