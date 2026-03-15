using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Products.Validator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
        {
            var dbContext = new ProductClientHubDbContext();

            Validate(clientId, dbContext, request);

            Product product = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = clientId
            };

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = product.Id,
                Name = product.Name
            };

        }

        private void Validate(Guid clientId, ProductClientHubDbContext dbContext, RequestProductJson request)
        {
            var clientExist = dbContext.Clients.Any(x => x.Id == clientId);

            if (!clientExist)
            {
                throw new NotFoundException("O Cliente nao existe");
            }

            var validator = new ProductValidator();

            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                throw new Exception(string.Join(Environment.NewLine, errors));
            }
        }
    }
}