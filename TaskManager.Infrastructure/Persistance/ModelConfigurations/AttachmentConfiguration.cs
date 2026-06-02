using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;

namespace TaskManager.Infrastructure.Persistance.ModelConfigurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Assignment)
            .WithMany(x => x.Attachments)
            .HasForeignKey(x => x.AssignmentId);

        builder.HasOne(x => x.Comment)
            .WithMany(x => x.Attachments)
            .HasForeignKey(x => x.CommentId);
    }
}
