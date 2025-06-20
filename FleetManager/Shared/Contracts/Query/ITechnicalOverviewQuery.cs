using Shared.Models.TechnicalOverview;

namespace Shared.Contracts.Query;

public interface ITechnicalOverviewQuery
{
    public Task<List<TechnicalOverviewModel>> GetTechnicalOverviewsAsync();

    public Task<List<TechnicalOverviewModel>?> GetTechnicalOverviewsForVehicleAsync(int id);

    public Task<TechnicalOverviewModel?> GetTechnicalOverviewByIdAsync(int id);

    public Task CreateTechnicalOverviewAsync(TechnicalOverviewModel model);

    public Task UpdateTechnicalOverviewAsync(TechnicalOverviewModel model);

    public Task DeleteTechnicalOverviewAsync(int id);
}
