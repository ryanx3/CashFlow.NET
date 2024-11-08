using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class ExpenseRepository : IExpensesRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpenseRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Expense expense)
    {
        _dbContext.Expenses.Add(expense);
       await _dbContext.SaveChangesAsync();
    }
}
