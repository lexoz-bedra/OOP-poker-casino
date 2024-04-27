using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestDealerFunctions
{
    [Fact]
    public void DoesShuffledDeckShuffle_InputIsDealer_ReturnTrue()
    {
        var dealer = new Dealer();
        var deckToCompare = new CardDeck();
        
        dealer.ShuffleDeck();

        var cardToCompare = deckToCompare.ShowCards()[1];
        var card = dealer.GetCards()[1];
        
        Assert.False(cardToCompare.Equals(card));
    }
    
    [Fact]
    public void CanDealerDealDeck_InputIsDealer_ReturnTrue() 
    {
        var dealer = new Dealer();
        
        dealer.ShuffleDeck();
        dealer.DealDeck();
        
        Assert.True(dealer.GetCards().Count == 0); 
    }
}