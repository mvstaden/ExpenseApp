

namespace ExpenseTracker.Api.DTOs
{
    public class CreateMonthlyPlanDto
    {
        public List<CreateIncomeSourceDto> IncomeSources { get; set; } = new List<CreateIncomeSourceDto>();
        public List<CreateRecurringExpenseDto> RecurringExpenses { get; set; } = new List<CreateRecurringExpenseDto>();
        public DateTime Payday { get; set; }
        public decimal SavingsGoal { get; set; }
    }
}