using CFinance.Application.DTOs.Budget;
using CFinance.Application.Interfaces.Services;
using CFinance.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CFinance.Api.Controllers;

[ApiController]
[Route("api/finance")]
[Authorize(Roles = "Finance,Admin")]
public class FinanceController : ControllerBase
{
    private readonly IBudgetService _budgetService;
    private readonly IReimbursementService _reimbursementService;

    public FinanceController(
        IBudgetService budgetService,
        IReimbursementService reimbursementService)
    {
        _budgetService = budgetService;
        _reimbursementService = reimbursementService;
    }

    //  BUDGET 

    [HttpPost("budget")]
    public async Task<IActionResult> SetBudget(SetBudgetRequest request)
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );

        await _budgetService.SetBudgetAsync(userId, request);
        return Ok("Budget set");
    }

    //  REIMBURSEMENT 

    [HttpGet("reimbursements")]
    public async Task<IActionResult> GetReimbursements(
        [FromQuery] ReimbursementStatus? status)
    {
        var result = await _reimbursementService.GetAllAsync(status);
        return Ok(result);
    }

    // APPROVE
    [HttpPut("reimbursements/{id}/approve")]
    public async Task<IActionResult> Approve(Guid id)
    {
        await _reimbursementService.ApproveAsync(id);
        return Ok("Reimbursement approved");
    }

    // REJECT
    [HttpPut("reimbursements/{id}/reject")]
    public async Task<IActionResult> Reject(Guid id)
    {
        await _reimbursementService.RejectAsync(id);
        return Ok("Reimbursement rejected");
    }
}
