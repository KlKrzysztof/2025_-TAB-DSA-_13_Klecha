using Shared.Models.OperationalActivity;

namespace Shared.Contracts.Query;

public interface IOperationalActivityQuery
{
    public Task<List<OperationalActivityModel>> GetOperationalActivitiesAsync();

    public Task<List<OperationalActivityModel>?> GetOperationalActivitiesForVehicle(int id);

    public Task<OperationalActivityModel?> GetOperationalActivityByIdAsync(int id);

    public Task CreateOperationalActivityAsync(OperationalActivityModel model);

    public Task UpdateOperationalActivityAsync(OperationalActivityModel model);

    public Task DeleteOperationalActivityAsync(int id);
}
