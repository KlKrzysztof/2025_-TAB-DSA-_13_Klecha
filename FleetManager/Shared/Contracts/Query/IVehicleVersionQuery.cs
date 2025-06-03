using Shared.Models.Vehicle;

namespace Shared.Contracts.Query;

public interface IVehicleVersionQuery
{
    public Task<List<VehicleVersion>> GetVehicleVersionsAsync();

    public Task<VehicleVersion?> GetVehicleVersionByIdAsync(int id);

    public Task CreateVehicleVersionAsync(VehicleVersion model);

    public Task UpdateVehicleVersionAsync(VehicleVersion model);

    public Task DeleteVehicleVersionAsync(int id);
}