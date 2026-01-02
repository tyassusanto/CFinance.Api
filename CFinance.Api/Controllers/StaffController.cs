using CFinance.Application.DTOs.Reimbursement;
using CFinance.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CFinance.Api.Controllers;

[ApiController]
[Route("api/staff")]
[Authorize(Roles = "Staff")]
public class StaffController : ControllerBase
{
    private readonly IReimbursementService _service;

    public StaffController(IReimbursementService service)
    {
        _service = service;
    }

    [HttpPost("reimbursements")]
    public async Task<IActionResult> Submit(SubmitReimbursementRequest request)
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );

        await _service.SubmitAsync(userId, request);
        return Ok("Reimbursement submitted");
    }
}
