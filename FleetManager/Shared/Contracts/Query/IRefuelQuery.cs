using Shared.Models.Refuel;

namespace Shared.Contracts.Query;

public interface IRefuelQuery
{
    public Task<List<RefuelModel>> GetRefuelsAsync();

    public Task<List<RefuelModel>?> GetRefuelsForVehicleAsync(int id);

    public Task<RefuelModel?> GetRefuelByIdAsync(int id);

    public Task CreateRefuelAsync(RefuelModel model);

    public Task UpdateRefuelAsync(RefuelModel model);

    public Task DeleteRefuelAsync(int id);
}