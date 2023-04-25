using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ManajemenTugasAkhirGeologi.Service.Commons.Contracts;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.CustomModels;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Inputs;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Services.Implementations;

public class LoginService : ILoginService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public LoginService(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<LoginCustomModel> Login(LoginInput input, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(input.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, input.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(AppConstants.UserIdClaim, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var jwtToken = GetToken(authClaims);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new LoginCustomModel { UserName = user.UserName, Token = token, Expiration = jwtToken.ValidTo };

        }
        return new LoginCustomModel();
    }
    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

        var token = new JwtSecurityToken
        (
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}