namespace CashFlow.Domain.Repositories.User
{
    public interface IUserRepository
    {
        Task Register(Entities.User user);
    }
}
