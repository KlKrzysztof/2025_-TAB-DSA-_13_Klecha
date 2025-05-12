using Shared.Models;

namespace Shared.Contracts.Query;

public interface IVehicleVersionQuery
{
    public Task<List<Vehicleversion>> GetVehicleVersionsAsync();

    public Task<Vehicleversion?> GetVehicleVersionByIdAsync(int id);

    public Task CreateVehicleVersionAsync(Vehicleversion model);

    public Task UpdateVehicleVersionAsync(Vehicleversion model);

    public Task DeleteVehicleVersionAsync(int id);
}