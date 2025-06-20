using Shared.Models;

namespace Shared.Contracts.Query;

public interface IVehicleQuery
{

    //piotrek service begin
    public Task<List<Vehicle>> GetVehiclesInServiceAsync();
    public Task<List<Vehicle>> GetVehiclesNotInServiceAsync();
    public Task UpdateSendToService(int id);
    public Task UpdateReturnFromService(int id);


    //piotrek service end

    public Task<List<Vehicle>> GetVehiclesAsync();

    public Task<Vehicle?> GetVehicleByIdAsync(int id);

    public Task<Vehicle?> GetVehicleByVinAsync(string vin);

    public Task<Vehicle?> GetVehicleByPlateNumber(string plateNumber);

    public Task CreateVehicleAsync(Vehicle model);

    public Task UpdateVehicleAsync(Vehicle model);

    public Task DeleteVehicleAsync(int id);
}