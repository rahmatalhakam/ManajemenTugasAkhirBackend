using ManajemenTugasAkhirGeologi.Commons.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ManajemenTugasAkhirGeologi.Commons.Models;

public class DbInitializer
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public DbInitializer(AppDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }
    public async Task Initialize()
    {
        _dbContext.Database.EnsureCreated();

        var roles = new string[]
        {
            AppConstants.UserRoles.Admin,
            AppConstants.UserRoles.Lecturer,
            AppConstants.UserRoles.Student
        };
        var roleStore = new RoleStore<IdentityRole>(_dbContext);
        foreach (var role in roles)
        {
            if (!_dbContext.Roles.Any(r => r.Name == role))
                await roleStore.CreateAsync(new IdentityRole { Name = role, NormalizedName = role.ToUpper() });
        }

        var admin = await _userManager.FindByNameAsync(AppConstants.UserRoles.Admin);
        if (admin == null)
        {
            var adminUser = new IdentityUser { UserName = AppConstants.UserRoles.Admin };
            await _userManager.CreateAsync(adminUser, "Passw0rd!");
            await _userManager.AddToRoleAsync(adminUser, AppConstants.UserRoles.Admin);
            await _userManager.SetLockoutEnabledAsync(adminUser, false);
        }
        await _dbContext.SaveChangesAsync();
    }
}