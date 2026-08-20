using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CashFlow.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        //O MigrateAsync() verifica quais migrations ainda não foram aplicadas e as executa no banco de dados.
        public static async Task Migrate(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<CashFlowDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
