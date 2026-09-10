namespace ExpenseTracker.Api.DTOs
{
    public class CreateMonthlyPlanDto
    {
        public decimal Income { get; set; }
        public DateTime Payday { get; set; }
        public decimal SavingsGoal { get; set; }
    }
}