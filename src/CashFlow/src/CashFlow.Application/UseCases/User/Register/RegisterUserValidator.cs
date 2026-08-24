using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Insira o nome do usuário");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Insira um email válido");
            RuleFor(u => u.Password).SetValidator(new PasswordValidator<RegisterUserJson>());
        }
    }
}
