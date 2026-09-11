using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Api.DTOs
{
    public class CreateIncomeSourceDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }

    }
}