using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title cannot be empty.");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The expenses cannot be for the future.");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The amount must be greater than zero.");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Payment type is not valid.");
    }
}
