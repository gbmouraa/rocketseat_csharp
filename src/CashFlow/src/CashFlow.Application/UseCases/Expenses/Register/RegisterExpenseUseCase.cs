using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expense;
using CashFlow.Domain.Repositories;
using CashFlow.Exceptions;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;

        // aqui e usado a instancia criada a partir da injecção de dependencias
        public RegisterExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisterExpenseJson> Execute(RequestRegisterExpenseJson request)
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

            await _expenseRepository.Add(entity);
            await _unitOfWork.Commit();
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
