using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestCasinoFunctions
{
    [Fact]
    public void DoesPlayerHaveBlackJack_InputIsHand_ReturnTrue()
    {
        var casino = new BlackjackCasino();
        var hand = new PlayerHand(new List<Card>()
        {
            new Card(CardValue.Ace, CardSuit.Clubs),
            new Card(CardValue.King, CardSuit.Clubs)
        });
        
        Assert.True(casino.CheckForBlackjack(new PlayerBuilder(hand.Cards).Build()));
    }
    
    [Fact]
    public void DoesPlayerHaveBlackJack_InputIsHand_ReturnFalse()
    {
        var casino = new BlackjackCasino();
        var hand = new PlayerHand(new List<Card>()
        {
            new Card(CardValue.Ace, CardSuit.Clubs),
            new Card(CardValue.Two, CardSuit.Clubs)
        });
        
        Assert.False(casino.CheckForBlackjack(new PlayerBuilder(hand.Cards).Build()));
    }
    
    [Fact]
    public void CanCasinoAccrueWinnings_InputIsPlayerAndBet_ReturnTrue()
    {
        var casino = new BlackjackCasino();
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int bet = 100;
        
        player.BuyChips(200);
        
        casino.AccrueWinnings(player, bet);
        
        Assert.Equal(400, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanCasinoAccrueLoss_InputIsPlayerAndBet_ReturnTrue()
    {
        var casino = new BlackjackCasino();
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int bet = 100;
        
        player.BuyChips(200);
        casino.AccrueLoss(player, bet);
        
        Assert.Equal(100, player.CasinoAccount.Chips);
    }
}