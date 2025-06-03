using Shared.Models;

namespace Shared.Contracts.Query;

public interface IContactInfoQuery
{
    public Task<List<Contactinfo>> GetContactInfosAsync();

    public Task<Contactinfo?> GetContactInfoByIdAsync(int id);

    public Task<List<Contactinfo>?> GetEmployeesContactInfoAsync(int id);

    public Task CreateContactInfoAsync(Contactinfo contactinfo);

    public Task UpdateContactInfoAsync(Contactinfo contactinfo);

    public Task DeleteContactInfoAsync(int id);
}
