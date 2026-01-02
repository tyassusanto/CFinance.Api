using CFinance.Application.Interfaces.Services;
using CFinance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CFinance.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly JwtTokenGenerator _jwt;

    public AuthController(
        IAuthService authService,
        JwtTokenGenerator jwt)
    {
        _authService = authService;
        _jwt = jwt;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _authService.ValidateUserAsync(
            request.Email, request.Password);

        var token = _jwt.Generate(user);

        return Ok(new
        {
            token,
            role = user.Role.ToString()
        });
    }
}

public record LoginRequest(string Email, string Password);
