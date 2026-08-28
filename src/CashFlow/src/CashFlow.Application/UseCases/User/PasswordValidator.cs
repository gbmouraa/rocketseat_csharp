using FluentValidation;
using FluentValidation.Validators;

namespace CashFlow.Application.UseCases.User
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "PasswordValidator";
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Insira uma senha");
                return false;
            }
            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "A senha deve conter no minimo 8 caracteres");
                return false;
            }

            return true;
        }
    }
}
