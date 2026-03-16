using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid ClientId)
        {
            var dbContext = new ProductClientHubDbContext();

            var client = dbContext.Clients.FirstOrDefault(x => x.Id == ClientId);

            if (client == null)
            {
                throw new NotFoundException("Produto nao encontrado");
            }

            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();
        }
    }
}
