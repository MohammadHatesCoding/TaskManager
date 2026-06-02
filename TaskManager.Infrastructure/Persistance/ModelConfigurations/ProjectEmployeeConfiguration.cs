using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.ModelConfigurations.BaseModelConfigurations;

namespace TaskManager.Infrastructure.Persistance.ModelConfigurations;

public class ProjectEmployeeConfiguration : BaseEntityConfiguration<ProjectEmployee>
{
    public override void Configure(EntityTypeBuilder<ProjectEmployee> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Project)
            .WithMany(x => x.ProjectEmployees)
            .HasForeignKey(x => x.ProjectId);

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.ProjectEmployees)
            .HasForeignKey(x => x.EmployeeId);

        builder.HasIndex(x => new{ x.ProjectId, x.EmployeeId});
    }
}