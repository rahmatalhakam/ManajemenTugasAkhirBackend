using ManajemenTugasAkhirGeologi.Service.Commons.Models.Entities;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Inputs;

namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Services.Interfaces;

public interface IStudentService
{
    Task<Student> Upsert(StudentInput input, CancellationToken cancellationToken);
    Task<bool> RemoveStudent(Guid studentId, CancellationToken cancellationToken);
}
