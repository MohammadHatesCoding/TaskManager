using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Models;

namespace TaskManager.Infrastructure.Persistance.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentEmployee> TaskEmployees { get; set; }
    public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Role>().ToTable("Role");
        modelBuilder.Entity<UserRole>().ToTable("UserRole");
        modelBuilder.Entity<RefreshToken>().ToTable("RefreshToken");
        modelBuilder.Entity<Comment>().ToTable("Comment");
        modelBuilder.Entity<Company>().ToTable("Company");
        modelBuilder.Entity<Department>().ToTable("Department");
        modelBuilder.Entity<Employee>().ToTable("Employee");
        modelBuilder.Entity<Attachment>().ToTable("Attachment");
        modelBuilder.Entity<Project>().ToTable("Project");
        modelBuilder.Entity<ProjectEmployee>().ToTable("ProjectEmployee");
        modelBuilder.Entity<Assignment>().ToTable("Assignment");
        modelBuilder.Entity<AssignmentEmployee>().ToTable("AssignmentEmployee");
        modelBuilder.Entity<PasswordResetToken>().ToTable("PasswordResetToken");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
