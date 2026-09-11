using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MonthlyPlan> MonthlyPlans { get; set; }
        public DbSet<RecurringExpense> RecurringExpenses { get; set; }
        public DbSet<IncomeSource> IncomeSources { get; set; }



    }


}