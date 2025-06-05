using Shared.Models.TechnicalOverview;

namespace Shared.Contracts.Query;

public interface ITechnicalOverviewQuery
{
    public Task<List<TechnicalOverview>> GetTechnicalOverviewsAsync();

    public Task<List<TechnicalOverview>?> GetTechnicalOverviewsForVehicleAsync(int id);

    public Task<TechnicalOverview?> GetTechnicalOverviewByIdAsync(int id);

    public Task CreateTechnicalOverviewAsync(TechnicalOverview model);

    public Task UpdateTechnicalOverviewAsync(TechnicalOverview model);

    public Task DeleteTechnicalOverviewAsync(int id);
}
