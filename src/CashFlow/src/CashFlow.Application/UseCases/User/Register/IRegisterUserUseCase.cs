using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        Task Execute(RegisterUserJson request);
    }
}
