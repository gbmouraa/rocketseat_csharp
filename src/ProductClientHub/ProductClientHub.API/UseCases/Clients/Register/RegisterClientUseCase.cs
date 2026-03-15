using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Validator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Execptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseShortClientJson Execute(RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            Client entity = new Client { Name = request.Name, Email = request.Email };

            dbContext.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortClientJson { Id = entity.Id, Name = entity.Name };
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
