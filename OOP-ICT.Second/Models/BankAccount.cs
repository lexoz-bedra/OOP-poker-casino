namespace OOP_ICT.Second.Models;

public class BankAccount : Account
{
    
    public BankAccount(int initialBalance) : base(initialBalance)
    {
        Balance = initialBalance;
    }
}