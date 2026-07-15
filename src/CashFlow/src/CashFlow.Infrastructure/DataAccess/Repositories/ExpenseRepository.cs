using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expense;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    // as interfaces de repositorios sempre ficam no domain
    // atraves delas podemos usar  os repositorios atraves da injecao de depencias
    internal class ExpenseRepository : IExpenseRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public ExpenseRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Expense expense)
        {
            await _dbContext.AddAsync(expense);
        }

        public async Task<List<Expense>> GetAll()
        {
            return await _dbContext.Expenses.AsNoTracking().ToListAsync();
        }

        public async Task<Expense?> GetById(long id)
        {
            return await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(long id)
        {
            var result = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
                return false;

            _dbContext.Expenses.Remove(result);
            return true;
        }

        public void Update(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
        }

        public async Task<List<Expense>> FilterByMonth(DateOnly date)
        {
            var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);

            var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date; // .Date no final faz com que seja o horario 00:00:00 da respectiva data
            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

            return await _dbContext.Expenses
                                    .AsNoTracking()
                                    .Where(expense => expense.Date >= startDate && expense.Date <= endDate)
                                    .OrderByDescending(expense => expense.Date)
                                    .ToListAsync();
        }
    }
}
