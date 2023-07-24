
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Data;
public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories {  get; set; }
    public DbSet<CoverType> CoverTypes {  get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<EmployeeRel> EmployeeRels { get; set; }
    public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
    public DbSet<EmployeeTest> EmployeeTests { get; set; }
    public DbSet<ProjectTest> ProjectTests { get; set; }
    public DbSet<FeeCollection> FeeCollections { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<User>()
			.HasIndex(u => u.UserName)
			.IsUnique();

        builder.Entity<EmployeeToProject>()
            .HasKey(u => new { u.EmployeeId, u.ProjectId });

        builder.Entity<EmployeeToProject>()
            .HasOne<EmployeeTest>(u => u.EmployeeTest)
            .WithMany(p => p.EmployeeToProjects);
        builder.Entity<EmployeeToProject>()
            .HasOne<ProjectTest>(u=>u.ProjectTest)
            .WithMany(p=>p.EmployeeToProjects); 

	}
}
