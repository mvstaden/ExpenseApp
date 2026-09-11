namespace ExpenseTracker.Api.DTOs
{
    public class MonthlyPlanResponseDto
    {
        public int Id { get; set; }
        public DateTime Payday { get; set; }
        public decimal SavingsGoal { get; set; }
        public List<IncomeSourceResponseDto> IncomeSources { get; set; } = new List<IncomeSourceResponseDto>();
    }
}