using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expense;
using CashFlow.Exceptions;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;

        // aqui ocorre o new de uma instancia por debaixo dos panos atraves da injecção de dependencias
        public RegisterExpenseUseCase(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            var entity = new Expense
            {
                Title = request.Title,
                Date = request.Date,
                Description = request.Description,
                PaymentType = (Domain.Enums.EnumPaymentType)request.PaymentType,
                Amount = request.Amount,
            };

            _expenseRepository.Add(entity);
            return new ResponseRegisterExpenseJson { Title = request.Title };
        }

        private void Validate(RequestRegisterExpenseJson request)
        {
            RegisterExpenseValidator validator = new();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                List<string> errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
