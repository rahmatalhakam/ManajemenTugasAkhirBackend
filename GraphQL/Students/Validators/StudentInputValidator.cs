using FluentValidation;
using ManajemenTugasAkhirGeologi.Commons.Models;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Inputs;
using Microsoft.EntityFrameworkCore;

namespace ManajemenTugasAkhirGeologi.GraphQL.Students.Validators;

public class StudentInputValidator : AbstractValidator<StudentInput>
{
    public StudentInputValidator(AppDbContext dbContext)
    {
        RuleFor(x => x.Nim).NotEmpty().Must(x => x.Length <= 10).WithMessage("Nim terlalu panjang.");
        RuleFor(x => x.Id).MustAsync(async (input, id, cancellationToken) =>
        {
            if (id == null) return true;
            return await dbContext.Students.AnyAsync(s => s.Id == id, cancellationToken);
        }).WithMessage("Mahasiswa tidak ditemukan.");
    }
}