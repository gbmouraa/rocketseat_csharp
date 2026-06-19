using CashFlow.Domain.Repositories.Expense;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CashFlow.Infrastructure.DataAccess
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            AddExpenseRepository(service);
            AddDbContext(service,config);
        }

        private static void AddExpenseRepository(IServiceCollection service)
        {
            service.AddScoped<IExpenseRepository, ExpenseRepository>();
        }

        private static void AddDbContext(IServiceCollection service, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Connection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 47));

            service.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString,serverVersion));
        }
    }
}

// para criação de uma extensão a classe e o metodo precisam ser estaticos
// o metodo precisa do this antes do tipo do parametro
// o tipo de parametro define para qual tipo de dados sera o metodo de extensao
