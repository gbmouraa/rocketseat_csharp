using CashFlow.Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            // quando uma classe recebe um parametro do tipo IRegisterExpenseUseCase
            // é usado uma instancia de RegisterExpenseUseCase através da injeção de dependencias
            service.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        }
    }
}
