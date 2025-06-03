using Shared.Models.Address;

namespace Shared.Contracts.Query;

public interface IAddressQuery
{
    public Task<List<Address>> GetAddressesAsync();

    public Task<Address?> GetAddressByIdAsync(int id);

    public Task<List<Address>?> GetAddressesByEmployeeIdAsync(int id);

    public Task CreateAddressAsync(Address address);

    public Task UpdateAddressAsync(Address address);

    public Task DeleteAddressAsync(int id);
}
