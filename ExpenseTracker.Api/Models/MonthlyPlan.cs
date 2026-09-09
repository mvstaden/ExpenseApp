namespace ExpenseTracker.Api.Models
{
    public class MonthlyPlan
    {
        public int Id { get; set; }
        public decimal Income { get; set; }

        public DateTime Payday { get; set; }

        public decimal SavingsGoal { get; set; }
        public List<RecurringExpense> RecurringExpenses { get; set; } = new List<RecurringExpense>();
    }
}