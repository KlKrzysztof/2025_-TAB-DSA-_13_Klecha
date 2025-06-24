using Shared.Models.User;

namespace Shared.Contracts.Query;

public interface IUserQuery
{
    public Task<List<UserModel>> GetUsersAsync();

    public Task<UserModel?> GetUserByIdAsync(int id);

    public Task<UserModel?> GetUserByEmployeeIdAsync(int id);

    public Task<UserModel?> GetUserByLoginAsync(string login);

    public Task<bool> Authenticate(string login, string password);

    public Task CreateUserAsync(UserModel user);

    public Task PatchLastLogin(int id);

    public Task UpdateUserAsync(UserModel user);

    public Task DeleteUserAsync(int id);
}