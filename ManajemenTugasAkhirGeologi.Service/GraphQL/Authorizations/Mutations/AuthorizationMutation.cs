using ManajemenTugasAkhirGeologi.Service.Commons.Contracts;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.CustomModels;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Inputs;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Services.Interfaces;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Users.Services.Interfaces;

namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Mutations;

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
