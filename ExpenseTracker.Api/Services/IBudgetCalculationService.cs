using ExpenseTracker.Api.Models;

namespace ExpenseTracker.Api.Services
{
    public interface IBudgetCalculationService
    {
        decimal CalculateTotalIncome(MonthlyPlan plan);
        decimal CalculateTotalRecurringExpenses(MonthlyPlan plan);
        decimal CalculateAvailableSpending(MonthlyPlan plan);
    }
}