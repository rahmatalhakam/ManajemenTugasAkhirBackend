using Microsoft.EntityFrameworkCore;

namespace ManajemenTugasAkhirGeologi.Service.Commons.Models.EntityBases;

public interface IEntityBaseBuilder<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{

}

