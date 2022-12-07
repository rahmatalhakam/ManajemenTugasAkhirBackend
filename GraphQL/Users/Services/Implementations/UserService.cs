using System.Security.Claims;
using ManajemenTugasAkhirGeologi.Commons.Contracts;
using ManajemenTugasAkhirGeologi.GraphQL.Users.Services.Interfaces;

namespace ManajemenTugasAkhirGeologi.GraphQL.Users.Services.Implementations;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _context;

    public UserService(IHttpContextAccessor context)
    {
        _context = context;
    }

    public Guid GetUserId()
    {
        var httpContext = _context.HttpContext;
        Guid userId = httpContext == null ? Guid.Empty : new Guid(httpContext.User.Claims.First(c => c.Type == AppConstants.UserIdClaim).Value);
        return userId;
    }

    public string GetUsername()
    {
        var httpContext = _context.HttpContext;
        var username = httpContext == null ? "" : httpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        return username;
    }
}