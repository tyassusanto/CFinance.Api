namespace CFinance.Application.DTOs.User;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
}
