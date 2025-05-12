using Shared.Models;

namespace Shared.Contracts.Query;

public interface IVehiclePurposeQuery
{
    public Task<List<Vehiclepurpose>> GetVehiclePurposesAsync();

    public Task<Vehiclepurpose?> GetVehiclePurposeByIdAsync(int id);

    public Task<Vehiclepurpose?> GetVehiclePurposeByNameAsync(string name);

    public Task CreateVehiclePurposeAsync(Vehiclepurpose model);

    public Task UpdateVehiclePurposeAsync(Vehiclepurpose model);

    public Task DeleteVehiclePurposeAsync(int id);
}