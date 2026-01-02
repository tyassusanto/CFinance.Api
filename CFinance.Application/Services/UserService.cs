using CFinance.Application.Common.Exceptions;
using CFinance.Application.DTOs.User;
using CFinance.Application.Interfaces.Repositories;
using CFinance.Application.Interfaces.Services;
using CFinance.Domain.Entities;
using CFinance.Domain.Enums;

namespace CFinance.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;


    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<UserResponse> CreateAsync(CreateUserRequest request)
    {
        if (await _repo.GetByEmailAsync(request.Email) != null)
            throw new Exception("Email already exists");

        if (!Enum.TryParse<UserRole>(request.Role, true, out var role))
            throw new Exception("Invalid role");

        var user = new User
        {
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = role,
            Balance = 0
        };

        await _repo.AddAsync(user);

        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role.ToString()
        };
    }
    public async Task AddBalanceAsync(Guid financeUserId, Guid targetUserId, decimal amount)
    {
        var finance = await _repo.GetByIdAsync(financeUserId)
            ?? throw new NotFoundException("Finance user not found");

        if (finance.Role != UserRole.Finance && finance.Role != UserRole.Admin)
            throw new BusinessException("Unauthorized");

        var user = await _repo.GetByIdAsync(targetUserId)
            ?? throw new NotFoundException("Target user not found");

        user.AddBalance(amount);

        await _repo.UpdateAsync(user);
    }
}
