using Microsoft.EntityFrameworkCore;
using Shared.Models.Address;
using Shared.Models.ContactInfo;
using Shared.Models.Employee;
using Shared.Models.User;

namespace FleetManager.Server.DataAccess.DbContexts;

public class EmployeeContext(DbContextOptions<EmployeeContext> opt) : DbContext(opt)
{
    public virtual DbSet<Employee> Employees { get; set; }

    public DbSet<UserModel> UsersInfo { get; set; }

    public DbSet<AddressModel> Addresses { get; set; }

    public DbSet<ContactInfoModel> ContactInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeModel>().ToTable("Employee");

        modelBuilder.Entity<UserModel>().ToTable("user");

        modelBuilder.Entity<AddressModel>().ToTable("address");

        modelBuilder.Entity<ContactInfoModel>().ToTable("contactinfo");
    }
}