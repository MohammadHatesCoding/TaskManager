using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.ModelConfigurations.BaseModelConfigurations;

namespace TaskManager.Infrastructure.Persistance.ModelConfigurations;

public class CommentConfiguration : BaseEntityConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Assignment)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.AssignmentId);

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.EmployeeId);
    }
}
