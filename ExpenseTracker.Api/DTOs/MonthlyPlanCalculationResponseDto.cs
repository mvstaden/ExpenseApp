using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Api.DTOs
{
    public class MonthlyPlanCalculationResponseDto
    {
        public int Id { get; set; }
        public DateTime Payday { get; set; }
        public decimal SavingsGoal { get; set; }

        public decimal TotalIncome { get; set; }
        public decimal TotalRecurringExpenses { get; set; }
        public decimal AvailableSpending { get; set; }
        public decimal DailyAllowance { get; set; }

        public List<IncomeSourceResponseDto> IncomeSources { get; set; }
    = new List<IncomeSourceResponseDto>();

        public List<RecurringExpenseResponseDto> RecurringExpenses { get; set; }
            = new List<RecurringExpenseResponseDto>();


    }
}