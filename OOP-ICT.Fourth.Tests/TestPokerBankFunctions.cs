using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class TestPokerBankFunctions
{
    [Fact]
    public void CanPokerBankAccrueWinnings_InputIsBank_ReturnTrue()
    {
        var bank = new PokerBank();
        var player = new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand());
        player.CasinoAccount.BuyChips(100);
        bank.AccrueWinnings(player, 100);
        
        Assert.Equal(200, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPokerBankAccrueLosses_InputIsBank_ReturnTrue()
    {
        var bank = new PokerBank();
        var player = new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand());
        player.CasinoAccount.BuyChips(100);
        bank.AccrueLoss(player, 100);
        
        Assert.Equal(0, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPokerBankTakeBet_InputIsBank_ReturnTrue()
    {
        var bank = new PokerBank();
        var player = new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand());
        player.CasinoAccount.BuyChips(100);
        bank.TakeBet(player, 100);
        
        Assert.Equal(100, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPokerBankCheckForSufficientFunds_InputIsBank_ReturnTrue()
    {
        var bank = new PokerBank();
        var player = new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand());
        player.CasinoAccount.BuyChips(100);
        var result = bank.CheckForSufficientFunds(player, 100);
        
        Assert.True(result);
    }
}