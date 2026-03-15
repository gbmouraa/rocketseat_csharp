using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.GetAll
{
    public class GetAllClientsUseCase
    {
        public ResponseAllClientsJson Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var clients = dbContext.Clients.ToList(); 

            return new ResponseAllClientsJson
            {
                Clients = clients.Select(c => new ResponseShortClientJson
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList()
            };
        }
    }
}
