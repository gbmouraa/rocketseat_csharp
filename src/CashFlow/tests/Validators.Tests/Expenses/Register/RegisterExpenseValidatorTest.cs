using CashFlow.Application.UseCases.Expenses.Register;
using CommonTestUtils;
using Shouldly;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTest
    {
        [Fact]
        public void Success()
        {
            // Arrange
            var validator = new RegisterExpenseValidator();
            var expenseRequest = RequestRegisterExpenseJsonBuilder.Build();

            // Act
            var result = validator.Validate(expenseRequest).IsValid;

            // Assert
            result.ShouldBeTrue();
        }
    }
}
