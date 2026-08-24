using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.User;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly CashFlowDbContext _dbContext;

        public UserRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Register(User user)
        {
            await _dbContext.User.AddAsync(user);
        }
    }
}
