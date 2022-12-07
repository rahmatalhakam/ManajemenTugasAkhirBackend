using HotChocolate.AspNetCore.Authorization;
using ManajemenTugasAkhirGeologi.Commons.Contracts;
using ManajemenTugasAkhirGeologi.Commons.Models;
using ManajemenTugasAkhirGeologi.Commons.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManajemenTugasAkhirGeologi.GraphQL.Students.Queries;

[ExtendObjectType(Name = AppConstants.Query)]
[Obsolete]
public class StudentQuery
{

    [Authorize]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Student> GetStudent([Service] AppDbContext dbContext, CancellationToken cancellationToken)
    {
        return dbContext.Students.AsNoTracking().AsQueryable();
    }
}
