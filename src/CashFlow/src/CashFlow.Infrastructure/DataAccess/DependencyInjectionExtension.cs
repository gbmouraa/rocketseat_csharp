using CashFlow.Domain.Repositories.Expense;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure.DataAccess
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            service.AddScoped<IExpenseRepository, ExpenseRepository>();
        }
    }
}

// para criação de uma extensão a classe e o metodo precisam ser estaticos
// o metodo precisa do this antes do tipo do parametro
// o tipo de parametro define para qual tipo de dados sera o metodo de extensao
