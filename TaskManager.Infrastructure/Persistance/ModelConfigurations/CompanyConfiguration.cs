using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.ModelConfigurations.BaseModelConfigurations;

namespace TaskManager.Infrastructure.Persistance.ModelConfigurations;

public class CompanyConfiguration : BaseEntityConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Companies)
            .HasForeignKey(x => x.OwnerId);
    }
}