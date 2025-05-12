using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace FleetManager.Server.DataAccess.DbContexts;

public class EmployeeContext(DbContextOptions<EmployeeContext> opt) : DbContext(opt)
{
    public virtual DbSet<EmployeeModel> Employees { get; set; }

    public virtual DbSet<User> UsersInfo { get; set; }

    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeModel>().ToTable("Employee")
            .HasOne(opt => opt.UserInfo)
            .WithOne(opt => opt.Employee)
            .HasForeignKey<User>(opt => opt.EmployeeId)
            .IsRequired();

        modelBuilder.Entity<User>().ToTable("User");

        modelBuilder.Entity<Address>().ToTable("address");
    }
}