namespace CFinance.Application.DTOs.Reimbursement;

public class SubmitReimbursementRequest
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = null!;
}
