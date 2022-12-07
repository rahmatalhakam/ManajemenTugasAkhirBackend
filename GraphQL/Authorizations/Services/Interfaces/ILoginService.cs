using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.CustomModels;
using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Inputs;

namespace ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Services.Interfaces;

public interface ILoginService
{
    Task<LoginCustomModel> Login(LoginInput input, CancellationToken cancellationToken);
}