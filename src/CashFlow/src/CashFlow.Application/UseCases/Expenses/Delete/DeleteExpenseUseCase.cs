using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expense;
using CashFlow.Exceptions;

namespace CashFlow.Application.UseCases.Expenses.Delete
{
    public class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {
        private readonly IExpenseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseUseCase(IExpenseRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            var result = await _repository.Delete(id);

            if (!result)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}

