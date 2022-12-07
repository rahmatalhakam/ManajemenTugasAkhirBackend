using ManajemenTugasAkhirGeologi.Commons.Contracts;
using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.CustomModels;
using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Inputs;
using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Services.Interfaces;
using ManajemenTugasAkhirGeologi.GraphQL.Users.Services.Interfaces;

namespace ManajemenTugasAkhirGeologi.GraphQL.Students.Mutations;

[ExtendObjectType(Name = AppConstants.Mutation)]
[Obsolete]
public class AuthorizationMutation
{
    public async Task<LoginCustomModel> Login(LoginInput input, [Service] ILoginService loginService, [Service] IUserService userService, CancellationToken cancellationToken)
    {
        var test = userService.GetUserId;
        Console.WriteLine(test);
        return await loginService.Login(input, cancellationToken);
    }
}
