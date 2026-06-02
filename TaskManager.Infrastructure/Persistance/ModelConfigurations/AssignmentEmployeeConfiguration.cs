using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.ModelConfigurations.BaseModelConfigurations;

namespace TaskManager.Infrastructure.Persistance.ModelConfigurations;

public class AssignmentEmployeeConfiguration : BaseEntityConfiguration<AssignmentEmployee>
{
    public override void Configure(EntityTypeBuilder<AssignmentEmployee> builder)
    {
        base.Configure(builder);

        builder.HasIndex(x => new { x.AssignmentId, x.EmployeeId });

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.AssignmentEmployees)
            .HasForeignKey(x => x.EmployeeId);

        builder.HasOne(x => x.Assignment)
            .WithMany(x => x.AssignmentEmployees)
            .HasForeignKey(x => x.AssignmentId);
    }
}