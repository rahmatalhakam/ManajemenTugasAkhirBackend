using System.IdentityModel.Tokens.Jwt;

namespace ManajemenTugasAkhirGeologi.GraphQL.Authorizations.CustomModels;

public class LoginCustomModel
{
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime? Expiration { get; set; }
}