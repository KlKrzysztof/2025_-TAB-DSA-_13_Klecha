using Shared.Models.Vehicle;

namespace Shared.Contracts.Query;

public interface IVehicleQuery
{
    public Task<List<Vehicle>> GetVehiclesAsync();

    public Task<Vehicle?> GetVehicleByIdAsync(int id);

    public Task<Vehicle?> GetVehicleByVinAsync(string vin);

    public Task<Vehicle?> GetVehicleByPlateNumber(string plateNumber);

    public Task<VehicleDetailsModel?> GetVehicleDetailsByIdAsync(int id);

    public Task CreateVehicleAsync(Vehicle model);

    public Task UpdateVehicleAsync(Vehicle model);

    public Task DeleteVehicleAsync(int id);
}