using Shared.Models;

namespace Shared.Contracts.Query;

public interface ITechnicalOverviewQuery
{
    public Task<List<Technicaloverview>> GetTechnicalOverviewsAsync();

    public Task<List<Technicaloverview>?> GetTechnicalOverviewsForVehicleAsync(int id);

    public Task<Technicaloverview?> GetTechnicalOverviewByIdAsync(int id);

    public Task CreateTechnicalOverviewAsync(Technicaloverview model);

    public Task UpdateTechnicalOverviewAsync(Technicaloverview model);

    public Task DeleteTechnicalOverviewAsync(int id);
}
