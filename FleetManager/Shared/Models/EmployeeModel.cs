using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class EmployeeModel
{
    [Key]
    public uint EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string Surname { get; set; } = null!;

    public string Pesel { get; set; } = null!;

    public ICollection<Address> Addresses { get; set; } = [];

    public Caretake? Caretake { get; set; }

    public ICollection<Contactinfo> Contactinfos { get; set; } = [];

    public required User UserInfo { get; set; }
}