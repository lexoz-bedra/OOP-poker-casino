namespace OOP_ICT.Second.Models;

public class CasinoAccount : Account
{
    public int Chips { get; private set; }
    public CasinoAccount(int initialBalance) : base(initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new InvalidOperationException("Negative balance.");
        }
        Balance = initialBalance;
    }
    
    public void BuyChips(int amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Chips += amount;
            return;
        }

        throw new NotEnoughMoneyException();
    }
    
    public void SellChips(int amount)
    {
        if (Chips >= amount)
        {
            Chips -= amount;
            Balance += amount;
            return;
        }

        throw new NotEnoughMoneyException("Not enough chips.");
    }
    
    public void GetChips(int amount)
    {
        Chips += amount;
    }
    
    public void GiveChips(int amount)
    {
        if (Chips >= amount)
        {
            Chips -= amount;
            return;
        }

        throw new NotEnoughMoneyException("Not enough chips.");
    }
}