using CashFlow.Application.UseCases.Expenses.Register;
using CommonTestUtils;

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
            Assert.True(result);
        }
    }
}
