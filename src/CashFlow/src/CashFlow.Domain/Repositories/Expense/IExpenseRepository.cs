namespace CashFlow.Domain.Repositories.Expense
{
    public interface IExpenseRepository
    {
        Task Add(Entities.Expense expense);
        Task<List<Entities.Expense>> GetAll();
        Task<Entities.Expense?> GetById(long id);
        Task<bool> Delete(long id);
    }
}
