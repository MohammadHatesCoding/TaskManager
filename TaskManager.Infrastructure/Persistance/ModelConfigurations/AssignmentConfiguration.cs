using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.ModelConfigurations.BaseModelConfigurations;

namespace TaskManager.Infrastructure.Persistance.ModelConfigurations;

public class AssignmentConfiguration : BaseEntityConfiguration<Assignment>
{
    public override void Configure(EntityTypeBuilder<Assignment> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Project)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.ProjectId);
    }
}