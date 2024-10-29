namespace CashFlow.Exception.ExceptionsBase;
public class ErrorOnValidationException : CashFlowException
{
    public List<string> Error { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        Error = errorMessages;
    }
}
