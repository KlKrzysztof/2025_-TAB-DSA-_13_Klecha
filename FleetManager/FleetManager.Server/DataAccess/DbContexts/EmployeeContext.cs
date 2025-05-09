using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace FleetManager.Server.DataAccess.DbContexts;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> opt)
         : base(opt)
    {
    }

    public virtual DbSet<EmployeeModel> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeModel>().ToTable("Employee");
    }
}