

namespace ExpenseTracker.Api.DTOs
{
    public class CreateMonthlyPlanDto
    {
        public List<CreateIncomeSourceDto> IncomeSources { get; set; } = new List<CreateIncomeSourceDto>();
        public DateTime Payday { get; set; }
        public decimal SavingsGoal { get; set; }
    }
}