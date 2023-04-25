using System.IdentityModel.Tokens.Jwt;

namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.CustomModels;

public class LoginCustomModel
{
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime? Expiration { get; set; }
}