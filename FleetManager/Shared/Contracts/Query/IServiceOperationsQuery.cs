using Shared.Models.ServiceOperation;

namespace Shared.Contracts.Query;

 public interface IServiceOperationsQuery
{
    public Task<List<ServiceOperation>> GetServiceOperationsAsync();

    public Task<List<ServiceOperation>?> GetServiceOperationsForVehicleAsync(int id);

    public Task<ServiceOperation?> GetServiceOperationByIdAsync(int id);

    public Task CreateServiceOperationAsync(ServiceOperation model);

    public Task UpdateServiceOperationAsync(ServiceOperation model);

    public Task DeleteServiceOperationsAsync(int id);
}
