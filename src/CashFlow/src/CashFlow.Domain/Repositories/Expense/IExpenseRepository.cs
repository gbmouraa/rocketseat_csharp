namespace CashFlow.Domain.Repositories.Expense
{
    public interface IExpenseRepository
    {
        Task Add(Entities.Expense expense);
    }
}
