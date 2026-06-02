using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.ModelConfigurations.BaseModelConfigurations;

namespace TaskManager.Infrastructure.Persistance.ModelConfigurations;

public class DepartmentConfiguration : BaseEntityConfiguration<Department>
{
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Manager)
            .WithMany()
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict); ;

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Departments)
            .HasForeignKey(x => x.CompanyId);
    }
}