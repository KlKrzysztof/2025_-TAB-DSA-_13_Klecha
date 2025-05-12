using Shared.Models;

namespace Shared.Contracts.Query;

public interface IVehicleOutfittingQuery
{
    public Task<List<Vehicleoutfitting>> GetVehicleoutfittingsAsync();

    public Task<Vehicleoutfitting?> GetVehicleoutfittingByIdAsync(int id);

    public Task CreateVehicleOutfittingAsync(Vehicleoutfitting model);

    public Task UpdateVehicleOutfittingAsync(Vehicleoutfitting model);

    public Task DeleteVehicleOutfittingAsync(int id);
}
