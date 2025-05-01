using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Employee
{
    public uint EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string Surname { get; set; } = null!;

    public string Pesel { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Caretake> Caretakes { get; set; } = new List<Caretake>();

    public virtual ICollection<Contactinfo> Contactinfos { get; set; } = new List<Contactinfo>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
