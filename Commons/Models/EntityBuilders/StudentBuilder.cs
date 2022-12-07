using ManajemenTugasAkhirGeologi.Commons.Models.Entities;
using ManajemenTugasAkhirGeologi.Commons.Models.EntityBases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManajemenTugasAkhirGeologi.Commons.Models.EntityBuilders;

public class StudentBuilder : EntityBaseBuilder<Student>
{

    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);
        builder.Property(s => s.Name).HasMaxLength(100);
        builder.Property(s => s.Nim).HasMaxLength(10);
        builder.HasIndex(s => s.Nim).IsUnique();
    }
}