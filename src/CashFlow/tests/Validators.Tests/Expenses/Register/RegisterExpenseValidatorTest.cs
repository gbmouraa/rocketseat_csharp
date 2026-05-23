using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTest
    {
        [Fact]
        public void Success()
        {
            // Arrange
            var validator = new RegisterExpenseValidator();

            var expenseRequest = new RequestRegisterExpenseJson
            {
                Amount = 100,
                Date = DateTime.Now.AddDays(-1),
                Description = "Some description here",
                PaymentType = EnumPaymentType.CreditCard,
                Title = "Apple",
            };

            // Act
            var result = validator.Validate(expenseRequest).IsValid;

            // Assert
            Assert.True(result);
        }
    }
}
