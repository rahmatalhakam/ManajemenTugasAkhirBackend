using ManajemenTugasAkhirGeologi.Commons.Models.Entities;
using ManajemenTugasAkhirGeologi.Commons.Models.EntityBuilders;
using ManajemenTugasAkhirGeologi.Extensions;
using ManajemenTugasAkhirGeologi.GraphQL.Users.Services.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManajemenTugasAkhirGeologi.Commons.Models;

public class AppDbContext : IdentityDbContext
{
    private readonly IUserService _userService;

    public AppDbContext(IUserService userService, DbContextOptions options) : base(options)
    {
        _userService = userService;
    }
    public DbSet<Student> Students { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new StudentBuilder().Configure(modelBuilder.Entity<Student>());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.SetAuditProperties(_userService.GetUserId());
        return await base.SaveChangesAsync(cancellationToken);
    }
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ChangeTracker.SetAuditProperties(_userService.GetUserId());
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override int SaveChanges()
    {
        ChangeTracker.SetAuditProperties(_userService.GetUserId());
        return base.SaveChanges();
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ChangeTracker.SetAuditProperties(_userService.GetUserId());
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

}
