using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Api.DTOs
{
    public class CreateRecurringExpenseDto
    {
        public string Name { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int DayOfMonth { get; set; }
    }
}