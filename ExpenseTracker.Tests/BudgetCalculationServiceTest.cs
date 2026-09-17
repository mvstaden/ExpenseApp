using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Services;

namespace ExpenseTracker.Tests
{
    public class BudgetCalculationServiceTest
    {
        [Fact]
        public void CalculateTotalIncome_ShouldReturnSumOfIncomeSources()
        {
            var plan = new MonthlyPlan
            {
                IncomeSources = new List<IncomeSource>
                {
                    new IncomeSource
                    {
                        Name = "SAP",
                        Amount = 90000
                    },
new IncomeSource
{
    Name = "Freelance",
Amount = 3000
}
                }
            };

            var service = new BudgetCalculationService();

            var result = service.CalculateTotalIncome(plan);

            Assert.Equal(93000, result);
        }


        [Fact]
        public void CalculateAvailableSpending_ShouldSubtractExpensesAndSavings()
        {
            var plan = new MonthlyPlan
            {
                SavingsGoal = 3000,
                IncomeSources = new List<IncomeSource>
                {
                    new IncomeSource
                    {
                        Name="SAP",
                        Amount=90000
                    },new IncomeSource
                    {
                        Name="CodeLab",
                        Amount=22700
                    }
                },
                RecurringExpenses = new List<RecurringExpense>
                {
                    new RecurringExpense
                    {
                        Name ="Rent",
                        Amount = 18000
                    },
                     new RecurringExpense
                    {
                        Name ="DebtBusters",
                        Amount = 14900
                    }
                }

            };

            var service = new BudgetCalculationService();

            var result = service.CalculateAvailableSpending(plan);

            Assert.Equal(76800, result);
        }
        [Fact]
        public void CalculateDaysInPayCycle_ShouldReturnNumberOfDaysBetweenPaydays()
        {
            var payday = new DateTime(2026, 9, 25);
            var nextPayday = new DateTime(2026, 10, 25);

            var service = new BudgetCalculationService();

            var result = service.CalculateDaysInPayCycle(payday, nextPayday);

            Assert.Equal(30, result);
        }

        [Fact]
        public void CalculateDaysInPayCycle_ShouldThrowException_WhenNextPaydayIsBeforePayday()
        {

            var payday = new DateTime(2026, 9, 25);
            var nextPayday = new DateTime(2026, 9, 20);

            var service = new BudgetCalculationService();

            Assert.Throws<ArgumentException>(() => service.CalculateDaysInPayCycle(payday, nextPayday));


        }

        [Fact]
        public void CalculateDailyAllowance_ShouldReturnDailySpendingAmount()
        {
            var plan = new MonthlyPlan
            {
                Payday = new DateTime(2026, 9, 25),
                SavingsGoal = 3000,

                IncomeSources = new List<IncomeSource>
        {
            new IncomeSource
            {
                Name = "SAP",
                Amount = 90000
            },
            new IncomeSource
            {
                Name = "CodeLab",
                Amount = 22700
            }
        },

                RecurringExpenses = new List<RecurringExpense>
        {
            new RecurringExpense
            {
                Name = "Rent",
                Amount = 18000
            },
            new RecurringExpense
            {
                Name = "DebtBusters",
                Amount = 14900
            }
        }
            };

            var nextPayday = new DateTime(2026, 10, 25);

            var service = new BudgetCalculationService();
            var result = service.CalculateDailyAllowance(plan, nextPayday);


            Assert.Equal(2560, result);

        }

        [Fact]
        public void CalculateTotalRecurringExpenses_ShouldReturnSumOfRecurringExpenses()
        {
            var plan = new MonthlyPlan
            {
                RecurringExpenses = new List<RecurringExpense>
        {
            new RecurringExpense
            {
                Name = "Rent",
                Amount = 18000
            },
            new RecurringExpense
            {
                Name = "DebtBusters",
                Amount = 14900
            },
            new RecurringExpense
            {
                Name = "Internet",
                Amount = 840
            }
        }
            };

            var service = new BudgetCalculationService();

            var result = service.CalculateTotalRecurringExpenses(plan);

            Assert.Equal(33740, result);
        }
    }

}