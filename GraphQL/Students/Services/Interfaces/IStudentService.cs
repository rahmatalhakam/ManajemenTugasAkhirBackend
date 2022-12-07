using ManajemenTugasAkhirGeologi.Commons.Models.Entities;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Inputs;

namespace ManajemenTugasAkhirGeologi.GraphQL.Students.Services.Interfaces;

public interface IStudentService
{
    Task<Student> Upsert(StudentInput input, CancellationToken cancellationToken);
    Task<bool> RemoveStudent(Guid studentId, CancellationToken cancellationToken);
}
