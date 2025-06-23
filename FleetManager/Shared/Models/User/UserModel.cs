using System.ComponentModel.DataAnnotations;

namespace Shared.Models.User;

public class UserModel
{
    [Key]
    public uint UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateOnly LastLogin { get; set; }

    public uint EmployeeId { get; set; }
}