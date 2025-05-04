using Shared.Models;

namespace Shared.Contracts.Query;

public interface IVehicleQuery
{
    public Task<List<Vehicle>> GetVehiclesAsync();

    public Task<Vehicle> GetVehicleByIdAsync(int id);
}