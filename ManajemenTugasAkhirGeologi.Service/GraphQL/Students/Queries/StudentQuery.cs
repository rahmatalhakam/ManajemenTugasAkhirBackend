using HotChocolate.AspNetCore.Authorization;
using ManajemenTugasAkhirGeologi.Service.Commons.Contracts;
using ManajemenTugasAkhirGeologi.Service.Commons.Models;
using ManajemenTugasAkhirGeologi.Service.Commons.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Queries;

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
