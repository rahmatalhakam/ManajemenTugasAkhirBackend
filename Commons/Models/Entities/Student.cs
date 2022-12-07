
using ManajemenTugasAkhirGeologi.Commons.Models.EntityBases;

namespace ManajemenTugasAkhirGeologi.Commons.Models.Entities;

public class Student : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Nim { get; set; } = string.Empty;

}