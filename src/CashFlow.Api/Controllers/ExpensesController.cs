using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpGet]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        return Created();
    }
}
