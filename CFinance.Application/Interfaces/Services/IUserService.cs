using CFinance.Application.DTOs.User;

namespace CFinance.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserResponse> CreateAsync(CreateUserRequest request);
}
