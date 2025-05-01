using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Address
{
    public uint AddressId { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public uint HouseNumber { get; set; }

    public uint? AccommodationNumber { get; set; }

    public uint? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
