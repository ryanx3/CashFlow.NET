using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var isTitleEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (isTitleEmpty)
        {
            throw new ArgumentException("The title cannot be empty.");
        }

        var isDateValid = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (isDateValid > 0)
        {
            throw new ArgumentException("The expenses cannot be for the future.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("The amount must be greater than zero.");
        }

        var EnumTypeExists = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (EnumTypeExists == false)
        {
            throw new ArgumentException("Payment type is not valid.");
        }
        
    }
}
