using Microsoft.EntityFrameworkCore;

namespace ManajemenTugasAkhirGeologi.Commons.Models.EntityBases;

public interface IEntityBaseBuilder<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{

}

