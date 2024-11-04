using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = new Expense {
            Title = request.Title,
            Description = request.Description,
            Amount  = request.Amount,
            Date = request.Date,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
        };

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var response = validator.Validate(request);

        if(response.IsValid == false)
        {
            var errorMessage = response.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessage);
        }

    }
}
