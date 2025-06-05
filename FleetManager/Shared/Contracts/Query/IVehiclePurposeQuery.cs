using Shared.Models.Vehicle;

namespace Shared.Contracts.Query;

public interface IVehiclePurposeQuery
{
    public Task<List<VehiclePurpose>> GetVehiclePurposesAsync();

    public Task<VehiclePurpose?> GetVehiclePurposeByIdAsync(int id);

    public Task<VehiclePurpose?> GetVehiclePurposeByNameAsync(string name);

    public Task CreateVehiclePurposeAsync(VehiclePurpose model);

    public Task UpdateVehiclePurposeAsync(VehiclePurpose model);

    public Task DeleteVehiclePurposeAsync(int id);
}