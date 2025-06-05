using System.ComponentModel.DataAnnotations;

namespace Shared.Models.ContactInfo;

public class ContactInfo
{
    [Key]
    public uint ContactId { get; set; }

    public uint EmployeeId { get; set; }

    public string TelNumber { get; set; } = null!;
}
