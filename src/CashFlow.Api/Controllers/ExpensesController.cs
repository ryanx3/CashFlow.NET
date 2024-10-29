using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        try
        {
            var response = new RegisterExpenseUseCase().Execute(request);
            return Created(string.Empty, response);
        }
        catch (ErrorOnValidationException ex)
        {
            var errorMessage = new ResponseErrorJson(ex.Error);
            return BadRequest(errorMessage);
        }
        catch {
            var errorMessage = new ResponseErrorJson("unknown error");
            return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
        }
    }
}
