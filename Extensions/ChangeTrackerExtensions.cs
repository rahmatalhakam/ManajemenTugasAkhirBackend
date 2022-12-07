using ManajemenTugasAkhirGeologi.Commons.Models.EntityBases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ManajemenTugasAkhirGeologi.Extensions;

public static class ChangeTrackerExtensions
{
    public static void SetAuditProperties(this ChangeTracker changeTracker, Guid userId)
    {
        changeTracker.DetectChanges();
        IEnumerable<EntityEntry> entities = changeTracker.Entries().Where
            (
                t =>
                t.Entity is IEntityBase
                && (t.State == EntityState.Deleted || t.State == EntityState.Added || t.State == EntityState.Modified)
            );

        foreach (EntityEntry entry in entities)
        {
            IEntityBase entity = (IEntityBase)entry.Entity;

            entity.DateModified = DateTime.UtcNow;
            entity.ModifiedBy = userId;

            if (entry.State == EntityState.Added)
            {
                entity.DateCreated = DateTime.UtcNow;
                entity.CreatedBy = userId;
            }
            if (entry.State == EntityState.Deleted)
            {
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

    }
}
