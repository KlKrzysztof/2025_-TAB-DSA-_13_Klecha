using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Address
{
    [Key]
    public uint AddressId { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public uint HouseNumber { get; set; }

    public uint? AccommodationNumber { get; set; }

    public uint? EmployeeId { get; set; }

    public virtual EmployeeModel? Employee { get; set; }
}
