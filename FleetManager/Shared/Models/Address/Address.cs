using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Address;

public class Address
{
    public Address()
    {
    }

    public Address(Address other)
    {
        AddressId = other.AddressId;
        City = other.City;
        Street = other.Street;
        PostalCode = other.PostalCode;
        HouseNumber = other.HouseNumber;
        AccommodationNumber = other.AccommodationNumber;
        EmployeeId = other.EmployeeId;
    }

    [Key]
    public uint AddressId { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public uint HouseNumber { get; set; }

    public uint? AccommodationNumber { get; set; }

    public uint? EmployeeId { get; set; }
}