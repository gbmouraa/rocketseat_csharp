using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductClientHubDbContext : DbContext
    {
        // DbSet deve ser de um tipo de uma entidade / o nome sempre é o nome da tabela
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                           // adicioanr essa connection string em AppSettings.Local
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Gabriel\\Documents\\ProductCLientHubDB.octet-stream");
        }

    }
}

