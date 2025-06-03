using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Employee;

public class Employee
{
    [Key]
    public uint EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string Surname { get; set; } = null!;

    public string Pesel { get; set; } = null!;
}