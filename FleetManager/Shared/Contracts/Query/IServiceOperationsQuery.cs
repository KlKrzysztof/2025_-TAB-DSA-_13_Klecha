using Shared.Models;

namespace Shared.Contracts.Query;

 public interface IServiceOperationsQuery
{
    public Task<List<Serviceoperation>> GetServiceOperationsAsync();

    public Task<List<Serviceoperation>?> GetServiceOperationsForVehicleAsync(int id);

    public Task<Serviceoperation?> GetServiceOperationByIdAsync(int id);

    public Task CreateServiceOperationAsync(Serviceoperation model);

    public Task UpdateServiceOperationAsync(Serviceoperation model);

    public Task DeleteServiceOperationsAsync(int id);
}
