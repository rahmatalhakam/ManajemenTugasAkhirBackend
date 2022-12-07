namespace ManajemenTugasAkhirGeologi.Commons.Models.EntityBases;
public abstract class EntityBase : IEntityBase
{
    public Guid Id { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}

