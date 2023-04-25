namespace ManajemenTugasAkhirGeologi.Service.Commons.Models.EntityBases;

public interface IEntityBase
{
    Guid Id { get; set; }
    DateTime? DateCreated { get; set; }
    DateTime? DateModified { get; set; }
    Guid? CreatedBy { get; set; }
    Guid? ModifiedBy { get; set; }
    bool IsDeleted { get; set; }
}
