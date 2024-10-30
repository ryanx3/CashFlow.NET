using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CommonTestUtilities.Requests;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpensesValidatorTests
{

    [Fact]
    public void Success()
    {
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        var response = validator.Validate(request);

        Assert.True(response.IsValid);
    }
}
