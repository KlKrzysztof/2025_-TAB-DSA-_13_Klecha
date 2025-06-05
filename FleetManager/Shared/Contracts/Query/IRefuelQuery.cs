using Shared.Models.Refuel;

namespace Shared.Contracts.Query;

public interface IRefuelQuery
{
    public Task<List<Refuel>> GetRefuelsAsync();

    public Task<List<Refuel>?> GetRefuelsForVehicleAsync(int id);

    public Task<Refuel?> GetRefuelByIdAsync(int id);

    public Task CreateRefuelAsync(Refuel model);

    public Task UpdateRefuelAsync(Refuel model);

    public Task DeleteRefuelAsync(int id);
}
