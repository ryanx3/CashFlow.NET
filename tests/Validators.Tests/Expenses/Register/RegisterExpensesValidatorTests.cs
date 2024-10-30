using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpensesValidatorTests
{

    [Fact]
    public void Success()
    {
        var validator = new RegisterExpenseValidator();
        var request = new RequestRegisterExpenseJson
        {
            Amount = 100,
            Date = DateTime.Now.AddDays(-1),
            Description = "Lorem ipsum",
            PaymentType = CashFlow.Communication.Enums.PaymentType.CreditCard,
            Title = "Title"
        };

        var response = validator.Validate(request);

        Assert.True(response.IsValid);
    }
}
