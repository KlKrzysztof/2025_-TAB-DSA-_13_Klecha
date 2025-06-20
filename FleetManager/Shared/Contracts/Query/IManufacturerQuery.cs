using Shared.Models.Manufacturer;

namespace Shared.Contracts.Query;

public interface IManufacturerQuery
{
    public Task<List<ManufacturerModel>> GetManufacturersAsync();

    public Task<ManufacturerModel?> GetManufacturerByIdAsync(int id);

    public Task<ManufacturerModel?> GetManufacturerByNameAsync(string name);

    public Task CreateManufacturerAsync(ManufacturerModel manufacturer);

    public Task UpdateManufacturerAsync(ManufacturerModel manufacturer);

    public Task DeleteManufacturerAsync(int id);
}
