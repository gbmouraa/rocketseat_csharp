using CashFlow.Domain.Repositories.Expense;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure.DataAccess
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            AddExpenseRepository(service);
            AddDbContext(service);
        }

        private static void AddExpenseRepository(IServiceCollection service)
        {
            service.AddScoped<IExpenseRepository, ExpenseRepository>();
        }

        private static void AddDbContext(IServiceCollection service)
        {
            service.AddDbContext<CashFlowDbContext>();
        }
    }
}

// para criação de uma extensão a classe e o metodo precisam ser estaticos
// o metodo precisa do this antes do tipo do parametro
// o tipo de parametro define para qual tipo de dados sera o metodo de extensao
