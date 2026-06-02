using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Models.BaseModel;

namespace TaskManager.Infrastructure.Persistance.ModelConfigurations.BaseModelConfigurations;

public abstract class BaseEntityConfiguration<TEntity> :
    IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}