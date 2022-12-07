using HotChocolate.AspNetCore.Authorization;
using ManajemenTugasAkhirGeologi.Commons.Models.Entities;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Inputs;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Services.Interfaces;

namespace ManajemenTugasAkhirGeologi.GraphQL.Students.Mutations;

[ExtendObjectType(Name = "Mutation")]
[Obsolete]
[Authorize]
public class StudentMutation
{
    public async Task<Student> UpsertStudent(StudentInput input, [Service] IStudentService studentService, CancellationToken cancellationToken)
    {
        return await studentService.Upsert(input, cancellationToken);
    }
    public async Task<bool> RemoveStudent(Guid studentId, [Service] IStudentService studentService, CancellationToken cancellationToken)
    {
        return await studentService.RemoveStudent(studentId, cancellationToken);
    }
}