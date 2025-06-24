using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Reservation;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/reservation")]
public class ReservationController(IReservationQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<ReservationModel> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

    [HttpGet("get/all")]
    public async Task<IActionResult> GetReservationsAsync()
    {
        var res = await query.GetReservationsAsync();
        return Ok(res);
    }

    [HttpGet("get/id/{id}")]
    public async Task<IActionResult> GetReservationByIdAsync(int id)
    {
        var res = await query.GetReservationByIdAsync(id);
        return Ok(res);
    }

    [HttpGet("get/vehicle/id/{id}")]
    public async Task<IActionResult> GetReservationsByVehicleId(int id)
    {
        var res = await query.GetReservationsByVehicleId(id);
        return Ok(res);
    }
    
    [HttpGet("get/employee/id/{id}")]
    public async Task<IActionResult> GetReservationsByEmployeeId(int id)
    {
        var res = await query.GetReservationsByEmployeeId(id);
        return Ok(res);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateReservationAsync(ReservationModel model)
    {
        try
        {
            await query.CreateReservationAsync(model);
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
    public async Task<IActionResult> UpdateReservationAsync(ReservationModel model)
    {
        try
        {
            await query.UpdateReservationAsync(model);
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
    public async Task<IActionResult> DeleteReservationAsync(int id)
    {
        try
        {
            await query.DeleteReservationAsync(id);
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