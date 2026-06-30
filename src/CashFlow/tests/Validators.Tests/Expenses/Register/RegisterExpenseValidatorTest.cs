using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Enums;
using CashFlow.Exceptions;
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
            var validator = new ExpenseValidator();
            var expenseRequest = RequestRegisterExpenseJsonBuilder.Build();

            // Act
            var result = validator.Validate(expenseRequest);

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Error_Title_Empty(string title)
        {
            // Arrange
            var validator = new ExpenseValidator();
            var expenseRequest = RequestRegisterExpenseJsonBuilder.Build();
            expenseRequest.Title = title;

            // Act
            var result = validator.Validate(expenseRequest);

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldHaveSingleItem();
            result.Errors.First().ErrorMessage.ShouldBe(ResourceErrorMessages.TITLE_REQUIRED);
        }

        [Fact]
        public void Error_PaymentType_Invalid()
        {
            // Arrange
            var validator = new ExpenseValidator();
            var expenseRequest = RequestRegisterExpenseJsonBuilder.Build();
            expenseRequest.PaymentType = (EnumPaymentType)700;

            // Act
            var result = validator.Validate(expenseRequest);

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldHaveSingleItem();
            result.Errors.First().ErrorMessage.ShouldBe(ResourceErrorMessages.INVALID_PAYMENT_TYPE);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-7)]
        public void Error_Amount_Invalid(decimal amount)
        {
            // Arrange
            var validator = new ExpenseValidator();
            var expenseRequest = RequestRegisterExpenseJsonBuilder.Build();
            expenseRequest.Amount = amount;

            // Act
            var result = validator.Validate(expenseRequest);

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldHaveSingleItem();
            result.Errors.First().ErrorMessage.ShouldBe(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THEN_ZERO);
        }

        [Fact]
        public void Error_Date_Invalid()
        {
            // Arrange
            var validator = new ExpenseValidator();
            var expenseRequest = RequestRegisterExpenseJsonBuilder.Build();
            expenseRequest.Date = DateTime.UtcNow.AddDays(1);

            // Act
            var result = validator.Validate(expenseRequest);

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldHaveSingleItem();
            result.Errors.First().ErrorMessage.ShouldBe(ResourceErrorMessages.INVALID_DATE);
        }
    }
}
