using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class TestButtonedPlayerFunctions
{
    [Fact]
    public void CanButtonedPlayerMoveButton_InputIsPlayer_ReturnTrue()
    {
        var player1 = new PokerPlayer(new BankAccount(100),
            new CasinoAccount(100), new PlayerHand());
        var player2 = new PokerPlayer(new BankAccount(100),
            new CasinoAccount(100), new PlayerHand());
        var button = new DealerButton();
        var deck = new CardDeck();

        player1.GiveButton(button, deck);
        player1.MoveButtonTo(player2);

        Assert.False(player2.Button is null);
        Assert.True(player1.Button is null);
    }
    
    [Fact]
    public void CanButtonedPlayerShuffleDeck_InputIsPlayer_ReturnTrue()
    {
        var player = new PokerPlayer(new BankAccount(100),
            new CasinoAccount(100), new PlayerHand());
        var player2 = new PokerPlayer(new BankAccount(100),
            new CasinoAccount(100), new PlayerHand());
        var deck = new CardDeck();
        var button = new DealerButton();
        player.GiveButton(button, deck);
        
        player.ShuffleDeck();
        
        player2.PokerHand.Hand.TakeCard(player.DealCard());
        var card = player2.PokerHand.Hand.ShowHand()[0];
        var deck2 = new CardDeck();
        var card2 = deck2.ShowCards().Last();
        Assert.NotEqual(card2.ToString(), card);
    }
    
    [Fact]
    public void CanButtonedPlayerDealCard_InputIsPlayer_ReturnTrue()
    {
        var player = new PokerPlayer(new BankAccount(100),
            new CasinoAccount(100), new PlayerHand());
        var player2 = new PokerPlayer(new BankAccount(100),
            new CasinoAccount(100), new PlayerHand());
        var deck = new CardDeck();
        var button = new DealerButton();
        player.GiveButton(button, deck);
        
        player.DealCard();
        
        player2.PokerHand.Hand.TakeCard(player.DealCard());
        var card = player2.PokerHand.Hand.ShowHand()[0];
        var deck2 = new CardDeck();
        var card2 = deck2.ShowCards().Last();
        Assert.NotEqual(card2.ToString(), card);
    }
}