using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.Delete;
using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            AddUseCases(service);
            AddAutoMapper(service);
        }

        private static void AddUseCases(IServiceCollection service)
        {
            // quando uma classe recebe um parametro do tipo IRegisterExpenseUseCase
            // é usado uma instancia de RegisterExpenseUseCase através da injeção de dependencias
            service.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
            service.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
            service.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
            service.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
        }
    }
}
