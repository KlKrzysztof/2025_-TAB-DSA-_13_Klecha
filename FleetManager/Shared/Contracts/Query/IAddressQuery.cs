using Shared.Models.Address;

namespace Shared.Contracts.Query;

public interface IAddressQuery
{
    public Task<List<AddressModel>> GetAddressesAsync();

    public Task<AddressModel?> GetAddressByIdAsync(int id);

    public Task<List<AddressModel>?> GetAddressesByEmployeeIdAsync(int id);

    public Task CreateAddressAsync(AddressModel address);

    public Task UpdateAddressAsync(AddressModel address);

    public Task DeleteAddressAsync(int id);
}
