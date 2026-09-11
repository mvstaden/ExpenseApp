using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.DTOs;
using ExpenseTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyPlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MonthlyPlansController(AppDbContext context)
        {
            _context = context;

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

            _context.MonthlyPlans.Add(monthlyPlan);

            await _context.SaveChangesAsync();

            var response = new MonthlyPlanResponseDto
            {
                Id = monthlyPlan.Id,
                Payday = monthlyPlan.Payday,
                SavingsGoal = monthlyPlan.SavingsGoal,
                IncomeSources = new List<IncomeSourceResponseDto>()

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

            return StatusCode(201, response);
        }


        [HttpGet]
        public async Task<IActionResult> GetMonthlyPlans()
        {
            var monthlyPlans = await _context.MonthlyPlans.Select(p => new MonthlyPlanResponseDto
            {
                Id = p.Id,
                Payday = p.Payday,
                SavingsGoal = p.SavingsGoal,
                IncomeSources = p.IncomeSources.Select(i => new IncomeSourceResponseDto
                {
                    Id = i.Id,
                    Amount = i.Amount,
                    Name = i.Name
                }).ToList()
            }).ToListAsync();




            return Ok(monthlyPlans);
        }
    }
}