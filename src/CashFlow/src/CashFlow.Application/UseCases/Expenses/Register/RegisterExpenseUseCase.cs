using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exceptions;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

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
