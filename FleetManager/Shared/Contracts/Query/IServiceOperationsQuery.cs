using Shared.Models.ServiceOperation;

namespace Shared.Contracts.Query;

 public interface IServiceOperationsQuery
{
    public Task<List<ServiceOperationModel>> GetServiceOperationsAsync();

    public Task<List<ServiceOperationModel>?> GetServiceOperationsForVehicleAsync(int id);

    public Task<ServiceOperationModel?> GetServiceOperationByIdAsync(int id);

    public Task CreateServiceOperationAsync(ServiceOperationModel model);

    public Task UpdateServiceOperationAsync(ServiceOperationModel model);

    public Task DeleteServiceOperationsAsync(int id);
}
