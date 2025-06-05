using Shared.Models.OperationalActivity;

namespace Shared.Contracts.Query;

public interface IOperationalActivityQuery
{
    public Task<List<Operationalactivity>> GetOperationalActivitiesAsync();

    public Task<List<Operationalactivity>?> GetOperationalActivitiesForVehicle(int id);

    public Task<Operationalactivity?> GetOperationalActivityByIdAsync(int id);

    public Task CreateOperationalActivityAsync(Operationalactivity model);

    public Task UpdateOperationalActivityAsync(Operationalactivity model);

    public Task DeleteOperationalActivityAsync(int id);
}
