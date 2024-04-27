namespace OOP_ICT.Second.Models;

public class Player
{
    public readonly BankAccount BankAccount;
    public readonly CasinoAccount CasinoAccount;
    public PlayerHand PlayerHand { get; private set; }
    public int Balance { get; private set; }

    public Player(BankAccount bankAccount, CasinoAccount casinoAccount, PlayerHand playerHand)
    {
        
        CasinoAccount = casinoAccount;
        BankAccount = bankAccount;
        PlayerHand = playerHand;
        Balance = 200;
    }
    
    public void TakeMoneyFromAccount(int amount, Account account)
    {
        if (account is null)
        {
            throw new InvalidOperationException("No account.");
        }
        account.WithdrawMoney(amount);
        Balance += amount;
    }
    

    public void PutMoneyToAccount(int amount, Account account)
    {
        if (account is null)
        {
            throw new InvalidOperationException("No account.");
        }
        if (Balance >= amount)
        {
            Balance -= amount;
            account.DepositMoney(amount);
            return;
        }
        
        throw new NotEnoughMoneyException();
    }
    
    
    public void BuyChips(int amount)
    {
        if (CasinoAccount is null)
        {
            throw new InvalidOperationException("No account.");
        }
        if (Balance >= amount)
        {
            Balance -= amount;
            CasinoAccount.BuyChips(amount);
            return;
        }

        throw new NotEnoughMoneyException();
    }
    
    public void SellChips(int amount)
    {
        if (CasinoAccount is null)
        {
            throw new InvalidOperationException("No account.");
        }
        
        if (CasinoAccount.Chips >= amount)
        {
            CasinoAccount.SellChips(amount);
            Balance += amount;
            return;
        }
        
        throw new NotEnoughMoneyException("Not enough chips.");
    }
    
    // function to provide casino the possibility to give chips to player for winning
    public void GetChips(int amount)
    {
        if (CasinoAccount is null)
        {
            throw new InvalidOperationException("No account.");
        }
        
        CasinoAccount.GetChips(amount);
    }
    
    // function to provide casino the possibility to take chips from player for losing
    public void GiveChips(int amount)
    {
        if (CasinoAccount is null)
        {
            throw new InvalidOperationException("No account.");
        }
        if (CasinoAccount.Chips >= amount)
        {
            CasinoAccount.GiveChips(amount);
            return;
        }
        
        throw new NotEnoughMoneyException("Not enough chips.");
    }
    
    
    public int Bet(int amount)
    {
        if (CasinoAccount is null)
        {
            throw new InvalidOperationException("No account.");
        }
        if (CasinoAccount.Chips >= amount)
        {
            return amount;
        }

        throw new NotEnoughMoneyException("Not enough chips.");
    }
}