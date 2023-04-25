using System.Security.Claims;
using HotChocolate.AspNetCore.Authorization;
using ManajemenTugasAkhirGeologi.Service.Commons.Contracts;
using ManajemenTugasAkhirGeologi.Service.Commons.Models.Entities;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Inputs;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Services.Interfaces;

namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Mutations;

[ExtendObjectType(Name = AppConstants.Mutation)]
[Obsolete]
public class StudentMutation
{
    [Authorize]
    public async Task<Student> UpsertStudent(StudentInput input, [Service] IStudentService studentService, ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken)
    {
        return await studentService.Upsert(input, cancellationToken);
    }

    [Authorize]
    public async Task<bool> RemoveStudent(Guid studentId, [Service] IStudentService studentService, CancellationToken cancellationToken)
    {
        return await studentService.RemoveStudent(studentId, cancellationToken);
    }
}