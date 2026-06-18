using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expense;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpenseRepository : IExpenseRepository
    {
        public void Add(Expense expense)
        {
            var dbContext = new CashFlowDbContext();
            dbContext.Add(expense);
            dbContext.SaveChanges();
        }
    }
}
