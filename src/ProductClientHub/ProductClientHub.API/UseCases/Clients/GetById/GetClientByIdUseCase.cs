using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.GetById
{
    public class GetClientByIdUseCase
    {
        public ResponseClientJson Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();

            var client = dbContext
                .Clients
                .Include(c => c.Products) // Inclui os produtos relacionados ao cliente
                .FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                throw new NotFoundException("Cliente nao existe.");
            }

            return new ResponseClientJson
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Products = client.Products.Select(p => new ResponseShortProductJson
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList()
            };

        }
    }
}