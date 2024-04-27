namespace OOP_ICT.Second.Models;

public abstract class Account
{
    public int Balance { get; protected set; }

    public Account(int initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new InvalidOperationException("Negative balance.");
        }
        Balance = initialBalance;
    }
    
    public void CheckNegativeAmount(int amount)
    {
        if (amount < 0)
        {
            throw new InvalidOperationException("Negative amount.");
        }
    }

    public void DepositMoney(int amount)
    {
        CheckNegativeAmount(amount);
        Balance += amount;
    }

    public void WithdrawMoney(int amount)
    {
        CheckNegativeAmount(amount);
        
        if (Balance >= amount)
        {
            Balance -= amount;
            return;
        }

        throw new NotEnoughMoneyException();
    }
}