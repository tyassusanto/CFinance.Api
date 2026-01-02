using CFinance.Application.DTOs.User;
using CFinance.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CFinance.Api.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IUserService _service;

    public AdminController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var result = await _service.CreateAsync(request);
        return Ok(result);
    }
}
