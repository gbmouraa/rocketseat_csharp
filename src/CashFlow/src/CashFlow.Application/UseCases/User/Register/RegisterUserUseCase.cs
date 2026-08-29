using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories;
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
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserUseCase(IMapper mapper, IPasswordEncript passwordEncript,
            IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _passwordEncript = passwordEncript;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseUserCreated> Execute(RegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            var passwordHash = _passwordEncript.Encript(request.Password);

            user.Password = passwordHash;
            user.UserIdentifier = Guid.NewGuid();

            await _repository.Register(user);
            await _unitOfWork.Commit();

            return new ResponseUserCreated { Name = user.Name };
        }

        private async Task Validate(RegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var emailExists = await _repository.EmailExists(request.Email);

            if (emailExists)
                result.Errors.Add(new ValidationFailure(string.Empty, "Email ja cadastrado"));

            if (!result.IsValid)
            {
                List<string> errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
