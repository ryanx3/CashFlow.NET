using CashFlow.Application.UseCases.Expenses.Register;
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

    [Fact]
    public void Error_Title_Empty()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        request.Title = "";

        var response = validator.Validate(request);

        response.IsValid.Should().BeFalse();
        response.Errors.Should().ContainSingle().
            And.Contain(error => error.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);
    }
}
