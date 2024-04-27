using OOP_ICT.Second.Models;
using OOP_ICT.Third.Models;
using Xunit;

namespace OOP_ICT.Third.Tests;

public class TestGameFunctions
{
    [Fact]
    public void DoesBetSizeSet_InputIsGame_ReturnTrue()
    {
        var game = new BlackjackGame();
        game.ChooseBetSize(200);
        
        Assert.True(game.Bet == 200);
    }
    
    [Fact]
    public void DoesPlayerAddToGame_InputIsGame_ReturnTrue()
    {
        var game = new BlackjackGame();
        var player = new PlayerBuilder().WithCasinoAccount(300).WithBankAccount(100).Build();
        player.BuyChips(200);
        
        game.AddPlayer(player);
        
        Assert.True(game.Players.Count == 1);
    }
    
    [Fact]
    public void DoesGameStart_InputIsGame_ReturnTrue()
    {
        var game = new BlackjackGame();
        var player = new PlayerBuilder().WithCasinoAccount(300).WithBankAccount(100).Build();
        player.BuyChips(200);
        
        game.AddPlayer(player);
        game.StartGame();
        
        Assert.True(game.Players[0].PlayerHand.Cards.Count >= 2);
        Assert.True(game.Dealer.Hand.Cards.Count >= 1);
    }
}