using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetAll
{
    public class GetAllPetsUseCase
    {
        public List<ResponsePetJson> Execute()
        {
            return new List<ResponsePetJson> {
                new ResponsePetJson{ Id = 1, Name = "Chop"}
            };
        }
    }
}
