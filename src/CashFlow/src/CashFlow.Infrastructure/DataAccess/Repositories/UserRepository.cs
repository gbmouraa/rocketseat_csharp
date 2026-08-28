using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly CashFlowDbContext _dbContext;

        public UserRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmailExists(string email)
            => await _dbContext.User.AnyAsync(x => x.Email.Equals(email));

        public async Task Register(User user)
            => await _dbContext.User.AddAsync(user);
    }
}
