using Shared.Models;

namespace Shared.Contracts.Query;

public interface IManufacturerQuery
{
    public Task<List<Manufacturer>> GetManufacturersAsync();

    public Task<Manufacturer?> GetManufacturerByIdAsync(int id);

    public Task<Manufacturer?> GetManufacturerByNameAsync(string name);

    public Task CreateManufacturerAsync(Manufacturer manufacturer);

    public Task UpdateManufacturerAsync(Manufacturer manufacturer);

    public Task DeleteManufacturerAsync(int id);
}
