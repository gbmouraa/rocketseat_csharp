namespace CashFlow.Domain.Repositories.Expense
{
    public interface IExpenseRepository
    {
        void Add(Entities.Expense expense);
    }
}
