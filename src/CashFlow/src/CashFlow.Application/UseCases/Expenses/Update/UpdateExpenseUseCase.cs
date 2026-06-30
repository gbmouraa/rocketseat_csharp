using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expense;
using CashFlow.Exceptions;

namespace CashFlow.Application.UseCases.Expenses.Update
{
    public class UpdateExpenseUseCase : IUpdateExpenseUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExpenseUseCase(IMapper mapper, IExpenseRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id, RequestExpenseJson request)
        {
            Validate(request);

            var expense = await _repository.GetById(id);

            if (expense is null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            _mapper.Map(request, expense); // mapea a entidade atual
            _repository.Update(expense);
            await _unitOfWork.Commit();

            // mapea para uma nova instância de Expense
            //_mapper.Map<Expense>(request);
        }

        private void Validate(RequestExpenseJson request)
        {
            ExpenseValidator validator = new();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                List<string> errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
