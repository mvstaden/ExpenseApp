using ExpenseTracker.Api.Models;

namespace ExpenseTracker.Api.Services
{
    public interface IBudgetCalculationService
    {
        decimal CalculateTotalIncome(MonthlyPlan plan);
        decimal CalculateTotalRecurringExpenses(MonthlyPlan plan);
        decimal CalculateAvailableSpending(MonthlyPlan plan);
        int CalculateDaysInPayCycle(DateTime payday, DateTime nextPayday);
        decimal CalculateDailyAllowance(MonthlyPlan plan, DateTime nextPayday);
    }
}