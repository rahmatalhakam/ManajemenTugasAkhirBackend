using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.CustomModels;
using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Inputs;
using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Services.Interfaces;

namespace ManajemenTugasAkhirGeologi.GraphQL.Students.Mutations;

[ExtendObjectType(Name = "Mutation")]
[Obsolete]
public class AuthorizationMutation
{
    public async Task<LoginCustomModel> Login(LoginInput input, [Service] ILoginService loginService, CancellationToken cancellationToken)
    {
        return await loginService.Login(input, cancellationToken);
    }
}
