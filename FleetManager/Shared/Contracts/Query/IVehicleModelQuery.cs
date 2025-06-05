using Shared.Models.Vehicle;

namespace Shared.Contracts.Query;

public interface IVehicleModelQuery
{
    public Task<List<VehicleModel>> GetVehicleModelsAsync();

    public Task<VehicleModel?> GetVehicleModelByIdAsync(int id);

    public Task CreateVehicleModelAsync(VehicleModel model);

    public Task UpdateVehicleModelAsync(VehicleModel model);

    public Task DeleteVehicleModelAsync(int id);
}