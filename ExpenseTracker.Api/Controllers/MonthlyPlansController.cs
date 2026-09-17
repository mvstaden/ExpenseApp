using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.DTOs;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyPlansController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBudgetCalculationService _budgetCalculationService;

        public MonthlyPlansController(AppDbContext context, IBudgetCalculationService budgetCalculationService)
        {
            _context = context;
            _budgetCalculationService = budgetCalculationService;

        }


        [HttpPost]
        public async Task<IActionResult> CreateMonthlyPlan(CreateMonthlyPlanDto dto)
        {
            var monthlyPlan = new MonthlyPlan
            {
                Payday = dto.Payday,
                SavingsGoal = dto.SavingsGoal
            };

            foreach (var incomeSource in dto.IncomeSources)
            {
                var newIncomeSource = new IncomeSource
                {
                    Name = incomeSource.Name,
                    Amount = incomeSource.Amount
                };
                monthlyPlan.IncomeSources.Add(newIncomeSource);
            }

            foreach (var recurringExpense in dto.RecurringExpenses)
            {
                var newRecurringExpense = new RecurringExpense
                {
                    Name = recurringExpense.Name,
                    Amount = recurringExpense.Amount,
                    DayOfMonth = recurringExpense.DayOfMonth
                };
                monthlyPlan.RecurringExpenses.Add(newRecurringExpense);
            }

            _context.MonthlyPlans.Add(monthlyPlan);

            await _context.SaveChangesAsync();

            var response = new MonthlyPlanResponseDto
            {
                Id = monthlyPlan.Id,
                Payday = monthlyPlan.Payday,
                SavingsGoal = monthlyPlan.SavingsGoal,
                IncomeSources = new List<IncomeSourceResponseDto>(),


            };

            foreach (var incomeSource in monthlyPlan.IncomeSources)
            {
                var incomeSourceResponse = new IncomeSourceResponseDto
                {
                    Id = incomeSource.Id,
                    Name = incomeSource.Name,
                    Amount = incomeSource.Amount
                };

                response.IncomeSources.Add(incomeSourceResponse);
            }

            foreach (var recurringExpense in monthlyPlan.RecurringExpenses)
            {
                var recurringExpenseResponse = new RecurringExpenseResponseDto
                {
                    Id = recurringExpense.Id,
                    Name = recurringExpense.Name,
                    Amount = recurringExpense.Amount,
                    DayOfMonth = recurringExpense.DayOfMonth
                };
                response.RecurringExpenses.Add(recurringExpenseResponse);
            }

            return StatusCode(201, response);
        }


        [HttpGet]
        public async Task<IActionResult> GetMonthlyPlans()
        {
            var monthlyPlans = await _context.MonthlyPlans.Include(p => p.IncomeSources).Include(p => p.RecurringExpenses).ToListAsync();

            var responses = new List<MonthlyPlanCalculationResponseDto>();

            foreach (var plan in monthlyPlans)
            {
                var totalIncome = _budgetCalculationService.CalculateTotalIncome(plan);

                var totalRecurringExpenses = _budgetCalculationService.CalculateTotalRecurringExpenses(plan);

                var availableSpending = _budgetCalculationService.CalculateAvailableSpending(plan);


                var response = new MonthlyPlanCalculationResponseDto
                {
                    Id = plan.Id,
                    Payday = plan.Payday,
                    SavingsGoal = plan.SavingsGoal,
                    TotalIncome = totalIncome,
                    TotalRecurringExpenses = totalRecurringExpenses,
                    AvailableSpending = availableSpending
                };

                foreach (var incomeSource in plan.IncomeSources)
                {
                    response.IncomeSources.Add(new IncomeSourceResponseDto
                    {
                        Id = incomeSource.Id,
                        Name = incomeSource.Name,
                        Amount = incomeSource.Amount
                    });
                }

                foreach (var recurringExpense in plan.RecurringExpenses)
                {
                    response.RecurringExpenses.Add(new RecurringExpenseResponseDto
                    {
                        Id = recurringExpense.Id,
                        Name = recurringExpense.Name,
                        Amount = recurringExpense.Amount,
                        DayOfMonth = recurringExpense.DayOfMonth
                    });
                }

                responses.Add(response);

            }
            return Ok(responses);


        }
    }
}