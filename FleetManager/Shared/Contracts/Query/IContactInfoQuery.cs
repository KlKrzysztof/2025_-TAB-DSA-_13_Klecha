using Shared.Models.ContactInfo;

namespace Shared.Contracts.Query;

public interface IContactInfoQuery
{
    public Task<List<ContactInfo>> GetContactInfosAsync();

    public Task<ContactInfo?> GetContactInfoByIdAsync(int id);

    public Task<List<ContactInfo>?> GetEmployeesContactInfoAsync(int id);

    public Task CreateContactInfoAsync(ContactInfo contactinfo);

    public Task UpdateContactInfoAsync(ContactInfo contactinfo);

    public Task DeleteContactInfoAsync(int id);
}
