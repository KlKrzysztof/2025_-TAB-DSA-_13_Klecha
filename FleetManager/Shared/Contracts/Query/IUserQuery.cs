using Shared.Models.User;

namespace Shared.Contracts.Query;

public interface IUserQuery
{
    public Task<List<UserModel>> GetUsersAsync();

    public Task<UserModel?> GetUserByIdAsync(int id);

    public Task<UserModel?> GetUserByEmployeeIdAsync(int id);

    public Task CreateUserAsync(UserModel user);

    public Task UpdateUserAsync(UserModel user);

    public Task DeleteUserAsync(int id);
}