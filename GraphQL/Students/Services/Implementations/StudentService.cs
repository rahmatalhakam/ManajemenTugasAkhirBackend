using ManajemenTugasAkhirGeologi.Commons.Models;
using ManajemenTugasAkhirGeologi.Commons.Models.Entities;
using ManajemenTugasAkhirGeologi.ErrorFilters;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Inputs;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManajemenTugasAkhirGeologi.GraphQL.Students.Services.Implementations;

public class StudentService : IStudentService
{
    private readonly AppDbContext _dbContext;

    public StudentService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Student> Upsert(StudentInput input, CancellationToken cancellationToken)
    {

        if (input.Id == null)
            return await InsertStudent(input, cancellationToken);
        else
            return await UpdateStudent(input, cancellationToken);

    }
    private async Task<Student> InsertStudent(StudentInput input, CancellationToken cancellationToken)
    {
        var student = await _dbContext.Students.IgnoreQueryFilters().SingleOrDefaultAsync(s => s.Nim == input.Nim, cancellationToken);
        if (student != null && !student.IsDeleted)
            throw new BusinessLogicException($"NIM {input.Nim} sudah terdaftar. Silahkan daftar mahasiswa lainnya!");
        else if (student != null && student.IsDeleted)
        {
            student.IsDeleted = false;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return student;
        }
        var newStudent = new Student { Name = input.Name, Nim = input.Nim };
        await _dbContext.Students.AddAsync(newStudent, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newStudent;
    }

    private async Task<Student> UpdateStudent(StudentInput input, CancellationToken cancellationToken)
    {
        var student = await _dbContext.Students.SingleAsync(s => s.Id == input.Id, cancellationToken);
        student.Name = input.Name;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return student;
    }

    public async Task<bool> RemoveStudent(Guid studentId, CancellationToken cancellationToken)
    {
        var student = await _dbContext.Students.SingleAsync(s => s.Id == studentId, cancellationToken);
        _dbContext.Remove(student);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

}
