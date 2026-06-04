using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Exceptions;
using CommonTestUtils;
using Shouldly;
using System.Collections.Frozen;

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
            var result = validator.Validate(expenseRequest);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void Error_Title_Empty()
        {
            // Arrange
            var validator = new RegisterExpenseValidator();
            var expenseRequest = RequestRegisterExpenseJsonBuilder.Build();
            expenseRequest.Title = string.Empty;

            // Act
            var result = validator.Validate(expenseRequest);

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldHaveSingleItem();
            result.Errors.First().ErrorMessage.ShouldBe(ResourceErrorMessages.TITLE_REQUIRED);
        }
    }
}
