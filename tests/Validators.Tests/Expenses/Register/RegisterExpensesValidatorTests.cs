using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpensesValidatorTests
{

    [Fact]
    public void Success()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        var response = validator.Validate(request);

        response.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        request.Title = title;

        var response = validator.Validate(request);

        response.IsValid.Should().BeFalse();
        response.Errors.Should().ContainSingle().
            And.Contain(error => error.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);
    }

    [Fact]
    public void Error_Date_Future()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        request.Date = DateTime.UtcNow.AddDays(1);

        var response = validator.Validate(request);

        response.IsValid.Should().BeFalse();
        response.Errors.Should().ContainSingle().
            And.Contain(error => error.ErrorMessage == ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE);
    }

    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        request.PaymentType = (PaymentType)333;

        var response = validator.Validate(request);

        response.IsValid.Should().BeFalse();
        response.Errors.Should().ContainSingle().
            And.Contain(error => error.ErrorMessage == ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Error_Amount_Invalid(decimal amount)
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        request.Amount = amount;

        var response = validator.Validate(request);

        response.IsValid.Should().BeFalse();
        response.Errors.Should().ContainSingle().
            And.Contain(error => error.ErrorMessage == ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
    }
}
