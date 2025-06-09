using Microsoft.EntityFrameworkCore;
using Shared.Models.Address;
using Shared.Models.ContactInfo;
using Shared.Models.Employee;
using Shared.Models.User;

namespace FleetManager.Server.DataAccess.DbContexts;

public class EmployeeContext(DbContextOptions<EmployeeContext> opt) : DbContext(opt)
{
    public virtual DbSet<Employee> Employees { get; set; }

    public DbSet<User> UsersInfo { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<ContactInfo> ContactInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employee");

        modelBuilder.Entity<User>().ToTable("User");

        modelBuilder.Entity<Address>().ToTable("address");

        modelBuilder.Entity<ContactInfo>().ToTable("contactinfo");
    }
}