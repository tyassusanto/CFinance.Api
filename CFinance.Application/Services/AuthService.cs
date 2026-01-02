using CFinance.Application.Interfaces.Repositories;
using CFinance.Application.Interfaces.Services;
using CFinance.Domain.Entities;

namespace CFinance.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;

    public AuthService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

public async Task<User> ValidateUserAsync(string email, string password)
{
    var user = await _userRepo.GetByEmailAsync(email)
        ?? throw new Exception("Invalid credentials");

    if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        throw new Exception("Invalid credentials");

    return user;
}
}
