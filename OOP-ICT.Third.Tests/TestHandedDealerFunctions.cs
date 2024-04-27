using OOP_ICT.FIrst.Tests;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Models;
using Xunit;

namespace OOP_ICT.Third.Tests;

public class TestHandedDealerFunctions : TestDealerFunctions
{
    [Fact]
    public void DoesDealerTakeCard_InputIsDealer_ReturnTrue()
    {
        var dealer = new DealerWithHand();
        var card = dealer.GetCards().Last();
        
        dealer.Hand.TakeCard(dealer.DealCard());
        
        Assert.True(dealer.Hand.Cards.Count == 1);
        Assert.True(dealer.Hand.Cards[0].Equals(card));
        Assert.True(dealer.GetCards().Count == 51);
    }
    
    [Fact]
    public void DoesDealerClearHand_InputIsDealer_ReturnTrue()
    {
        var dealer = new DealerWithHand();
        
        dealer.Hand.TakeCard(dealer.DealCard());
        dealer.Hand.TakeCard(dealer.DealCard());
        dealer.Hand.ClearHand();
        
        Assert.True(dealer.Hand.Cards.Count == 0);
    }
    
    [Fact]
    public void DoesDealerGetTotalPoints_InputIsDealer_ReturnTrue()
    {
        var game = new BlackjackGame();
        game.ChooseBetSize(100);

        var player1 = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(300).Build();
        var player2 = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(300).Build();
        player1.BuyChips(200);
        player2.BuyChips(200);
        game.AddPlayer(player1);
        game.AddPlayer(player2);
        game.StartGame();
        
        Assert.True(game.GetTotalPoints(game.Dealer.Hand) >= 0);
    }
    
    [Fact]
    public void DoesDealerCheckEmptyDeck_InputIsDealer_ReturnTrue()
    {
        var dealer = new DealerWithHand();
        
        dealer.DealDeck();
        
        Assert.True(dealer.IsDeckEmpty());
    }
}