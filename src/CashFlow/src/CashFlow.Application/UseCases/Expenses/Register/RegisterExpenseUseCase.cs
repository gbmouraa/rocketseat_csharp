using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exceptions;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            var dbContext = new CashFlowDbContext();

            var entity = new Expense
            {
                Title = request.Title,
                Date = request.Date,
                Description = request.Description,
                PaymentType = (CashFlow.Domain.Enums.EnumPaymentType)request.PaymentType,
                Amount = request.Amount,
            };

            dbContext.Add(entity);
            dbContext.SaveChanges();

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
