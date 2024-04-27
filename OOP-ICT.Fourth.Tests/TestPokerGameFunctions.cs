using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class TestPokerGameFunctions
{
    [Fact]
    public void CanNewPokerGameStart_InputIsGame_ReturnTrue()
    {
        var players = new List<PokerPlayer>();
        players.Add(new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand()));
        players.Add(new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand()));
        players[0].CasinoAccount.BuyChips(100);
        players[1].CasinoAccount.BuyChips(100);
        var button = new DealerButton();
        var bank = new PokerBank();
        
        var game = new PokerGame(players, button, bank);
        game.StartNewGame(players, 100);
        
        Assert.Equal(100, players[0].CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPokerGameDealCards_InputIsGame_ReturnTrue()
    {
        var players = new List<PokerPlayer>();
        players.Add(new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand()));
        players.Add(new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand()));
        players[0].CasinoAccount.BuyChips(100);
        players[1].CasinoAccount.BuyChips(100);
        var button = new DealerButton();
        var bank = new PokerBank();
        
        var game = new PokerGame(players, button, bank);
        players[0].GiveButton(button, new CardDeck());
        game.DealCards(players);
        
        Assert.Equal(5, players[1].PokerHand.Hand.Cards.Count);
    }
    
    [Fact]
    public void CanPokerGameGetBets_InputIsGame_ReturnTrue()
    {
        var players = new List<PokerPlayer>();
        players.Add(new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand()));
        players.Add(new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand()));
        players[0].CasinoAccount.BuyChips(100);
        players[1].CasinoAccount.BuyChips(100);
        var button = new DealerButton();
        var bank = new PokerBank();
        
        var game = new PokerGame(players, button, bank);
        game.StartNewGame(players, 100);
        game.GetBets(100);
        
        Assert.Equal(100, players[0].CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPokerGameCompareHands_InputIsGame_ReturnTrue()
    {
        var players = new List<PokerPlayer>();
        players.Add(new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand()));
        players.Add(new PokerPlayer(new BankAccount(100), new CasinoAccount(100), new PlayerHand()));
        players[0].CasinoAccount.BuyChips(100);
        players[1].CasinoAccount.BuyChips(100);
        var button = new DealerButton();
        var bank = new PokerBank();
        
        var game = new PokerGame(players, button, bank);
        game.StartNewGame(players, 100);
        game.GetBets(100);
        game.DealCards(players);
        game.CompareHands(players, 100);
        
        Assert.Equal(300, players[0].CasinoAccount.Chips);
    }
}