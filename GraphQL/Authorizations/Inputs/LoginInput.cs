namespace ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Inputs;

public class LoginInput
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}