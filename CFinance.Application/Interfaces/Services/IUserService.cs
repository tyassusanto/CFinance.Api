using CFinance.Application.DTOs.User;

namespace CFinance.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserResponse> CreateAsync(CreateUserRequest request);
    Task AddBalanceAsync(Guid financeUserId, Guid targetUserId, decimal amount);
}
