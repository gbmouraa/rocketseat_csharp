using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security;
using CashFlow.Exceptions;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.User.Register
{
    internal class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncript _passwordEncript;
        private readonly IUserRepository _repository;

        public RegisterUserUseCase(IMapper mapper, IPasswordEncript passwordEncript, IUserRepository repository)
        {
            _mapper = mapper;
            _passwordEncript = passwordEncript;
            _repository = repository;
        }

        public async Task<ResponseUserCreated> Execute(RegisterUserJson request)
        {
            Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            var passwordHash = _passwordEncript.Encript(request.Password);
            user.Password = passwordHash;

            return new ResponseUserCreated { Name = user.Name };
        }

        private async void Validate(RegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var emailExists = await _repository.EmailExists(request.Email);

            if (emailExists)
                result.Errors.Add(new ValidationFailure(string.Empty, "Email ja cadastrado"));

            if (!result.IsValid)
                throw new ErrorOnValidationException(result.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
