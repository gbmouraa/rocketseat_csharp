using CashFlow.Communication.Requests;
using CashFlow.Exceptions;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses
{
    public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
    {
        public ExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THEN_ZERO);
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.Now).WithMessage(ResourceErrorMessages.INVALID_DATE);
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_PAYMENT_TYPE);
        }
    }
}
