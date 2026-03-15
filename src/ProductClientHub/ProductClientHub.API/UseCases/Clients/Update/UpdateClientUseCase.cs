using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Validator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionsBase;
using ProductClientHub.Execptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Update
{
    public class UpdateClientUseCase
    {
        public void Execute(Guid id, RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            var client = dbContext.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                throw new NotFoundException("Usuario nao encontraddo");
            }

            client.Name = request.Name;
            client.Email = request.Email;

            dbContext.Update(client);
            dbContext.SaveChanges();
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new ClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
