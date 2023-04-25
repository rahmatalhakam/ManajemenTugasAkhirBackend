using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.CustomModels;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Inputs;

namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Services.Interfaces;

public interface ILoginService
{
    Task<LoginCustomModel> Login(LoginInput input, CancellationToken cancellationToken);
}