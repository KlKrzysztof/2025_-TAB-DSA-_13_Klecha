using Shared.Models.Vehicle;

namespace Shared.Contracts.Query;

public interface IVehicleOutfittingQuery
{
    public Task<List<VehicleOutfitting>> GetVehicleoutfittingsAsync();

    public Task<VehicleOutfitting?> GetVehicleoutfittingByIdAsync(int id);

    public Task CreateVehicleOutfittingAsync(VehicleOutfitting model);

    public Task UpdateVehicleOutfittingAsync(VehicleOutfitting model);

    public Task DeleteVehicleOutfittingAsync(int id);
}
