using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Api.Models
{
    public class RecurringExpense
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int MonthlyPlanId { get; set; }
        public MonthlyPlan? MonthlyPlan { get; set; }

    }
}