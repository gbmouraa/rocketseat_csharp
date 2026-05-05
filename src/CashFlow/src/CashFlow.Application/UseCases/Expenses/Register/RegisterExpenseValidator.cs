using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage("O titulo nao pode ser vazio");
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("O valor deve ser maior que zero");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.Now).WithMessage("Data nao pode estar a frente da data atual");
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Meio de pagamento e invalido");
        }
    }
}
