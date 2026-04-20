using Petfolio.Communication.Responses;
using Petfolio.Communication.Requests;

namespace Petfolio.Application.UseCases.Pet.Register
{
    public class RegisterPetUseCase
    {
        public ResponsePetJson Execute(PetJson request)
        {
            return new ResponsePetJson { Id = 1, Name = request.Name };
        }
    }
}
