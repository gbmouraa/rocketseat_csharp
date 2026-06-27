using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expense;
using CashFlow.Exceptions;

namespace CashFlow.Application.UseCases.Expenses.GetById
{
    public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {
        private readonly IExpenseRepository _repository;
        private readonly IMapper _mapper;

        public GetExpenseByIdUseCase(IExpenseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseFullExpenseJson> Execute(long id)
        {
            var result = await _repository.GetById(id);

            if (result == null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            return _mapper.Map<ResponseFullExpenseJson>(result);
        }
    }
}
