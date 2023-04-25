using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManajemenTugasAkhirGeologi.Service.Commons.Models.EntityBases;

public abstract class EntityBaseBuilder<TEntity> : IEntityBaseBuilder<TEntity> where TEntity : class, IEntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}

