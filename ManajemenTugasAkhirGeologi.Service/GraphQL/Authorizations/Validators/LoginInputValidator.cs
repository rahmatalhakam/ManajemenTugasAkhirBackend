using FluentValidation;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Inputs;

namespace ManajemenTugasAkhirGeologi.Service.GraphQL.Authorizations.Validators;

public class LoginInputValidator : AbstractValidator<LoginInput>
{
    public LoginInputValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username must not be empty.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password must not be empty.");
    }
}