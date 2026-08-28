using CashFlow.Domain.Security;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security
{
    internal class PasswordEncript : IPasswordEncript
    {
        public string Encript(string password)
            => BC.HashPassword(password);
    }
}
