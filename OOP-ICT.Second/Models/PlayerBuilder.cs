using OOP_ICT.Models;

namespace OOP_ICT.Second.Models;

public class PlayerBuilder
{
    private BankAccount _bankAccount;
    private CasinoAccount _casinoAccount;
    private readonly PlayerHand _hand;
    
    public PlayerBuilder()
    {
        _hand = new PlayerHand();
    }

    public PlayerBuilder(List<Card> cards)
    {
        _hand = new PlayerHand(cards);
    }
    
    public PlayerBuilder WithBankAccount(int initialBalance)
    {
        _bankAccount = new BankAccount(initialBalance);
        return this;
    }

    public PlayerBuilder WithCasinoAccount(int initialBalance)
    {
        _casinoAccount = new CasinoAccount(initialBalance);
        return this;
    }

    public Player Build()
    {
        return new Player(_bankAccount, _casinoAccount, _hand);
    }
}