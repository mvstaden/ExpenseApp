using ExpenseTracker.Api.Models;

namespace ExpenseTracker.Api.Services
{
    public class BudgetCalculationService : IBudgetCalculationService
    {
        public decimal CalculateTotalIncome(MonthlyPlan plan)
        {
            var totalIncome = plan.IncomeSources.Sum(i => i.Amount);
            return totalIncome;
        }

        public decimal CalculateTotalRecurringExpenses(MonthlyPlan plan)
        {
            var totalRecurringExpenses = plan.RecurringExpenses.Sum(e => e.Amount);

            return totalRecurringExpenses;
        }

        public decimal CalculateAvailableSpending(MonthlyPlan plan)
        {
            var totalAvailableSpending = CalculateTotalIncome(plan) - CalculateTotalRecurringExpenses(plan) - plan.SavingsGoal;
            return totalAvailableSpending;
        }

    }
}