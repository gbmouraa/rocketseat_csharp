using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expense;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    public class GetAllExpensesUseCase : IGetAllExpensesUseCase
    {
        // o dbContext  não é usado nos services/use cases
        // quem acessa o db context é o repository em infrastructure
        private readonly IExpenseRepository _repository;
        private readonly IMapper _mapper;

        public GetAllExpensesUseCase(IExpenseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseExpensesJson> Execute()
        {
            var expenses = await _repository.GetAll();

            return new ResponseExpensesJson
            { //                            destino            source
                Expenses = _mapper.Map<List<ShortExpenseJson>>(expenses)
            };
        }
    }
}
