using FleetManager.Server.Controllers.Creator;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Query;
using Shared.Models.Employee;

namespace FleetManager.Server.Controllers;

[ApiController]
[Route("api/employee")]
public class EmployeeController(IEmployeeQuery query) : ControllerBase
{
    private readonly ErrorStringsCreator<EmployeeModel> exCreator = new();

    private readonly ErrorStringsCreator<int> exCreatorInt = new();

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
    public async Task<IActionResult> CreateEmployee(Employee model)
    {
        try
        {
            await query.CreateEmployee(model);
            return Ok();
        }
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("put", model, ex);
            return StatusCode(500, msg);
            throw;
        }
    }

    [HttpPut("create/contact/{c1}/{c2}")]
    public async Task<IActionResult> CreateEmployeeWithContactInfos(EmployeeModel model, string c1, string c2)
    {
        try
        {
            await query.CreateEmployeeWithContactInfo(model, c1, c2);
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
    public async Task<IActionResult> UpdateEmployee(Employee model)
    {
        try
        {
            await query.UpdateEmployee(model);
            return Ok();
        }
        catch (Exception ex)
        {
            var msg = exCreator.ConstructErrorMessage("post", model, ex);
            return StatusCode(500, msg);
            throw;
        }
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            await query.DeleteEmployee(id);
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