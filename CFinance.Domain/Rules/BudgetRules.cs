namespace CFinance.Domain.Rules;

public static class BudgetRules
{
    public const decimal MaxPercentage = 0.4m;

    public static bool IsWithinLimit(decimal balance, decimal budget)
    {
        return budget <= balance * MaxPercentage;
    }
}