using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.DTOs;
using ExpenseTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
                Income = dto.Income,
                Payday = dto.Payday,
                SavingsGoal = dto.SavingsGoal
            };

            _context.MonthlyPlans.Add(monthlyPlan);

            await _context.SaveChangesAsync();

            return StatusCode(201, monthlyPlan);
        }
    }
}