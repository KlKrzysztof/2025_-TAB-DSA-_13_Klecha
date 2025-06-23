using Shared.Models.ContactInfo;

namespace Shared.Contracts.Query;

public interface IContactInfoQuery
{
    public Task<List<ContactInfoModel>> GetContactInfosAsync();

    public Task<ContactInfoModel?> GetContactInfoByIdAsync(int id);

    public Task<List<ContactInfoModel>?> GetEmployeesContactInfoAsync(int id);

    public Task CreateContactInfoAsync(ContactInfoModel contactinfo);

    public Task UpdateContactInfoAsync(ContactInfoModel contactinfo);

    public Task DeleteContactInfoAsync(int id);
}
