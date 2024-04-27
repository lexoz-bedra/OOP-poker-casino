namespace OOP_ICT.Second.Models;

public class Bank
{
    
    public void GiveMoney(BankAccount account, int amount)
    {
        account.DepositMoney(amount);
    }

    public void TakeMoney(BankAccount account, int amount)
    {
        account.WithdrawMoney(amount);
    }
}