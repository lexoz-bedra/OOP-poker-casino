using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestDeckFunctions
{
    [Fact]
    public void IsNewDeckNotEmpty_InputIsDeck_ReturnTrue()
    {
        var deck = new CardDeck();
        
        Assert.False(deck.IsEmpty());
    }

    [Fact]
    public void DoesNewDeckContain52Cards_InputIsDeck_Return_True()
    {
        var deck = new CardDeck();
        
        Assert.Equal(52, deck.CountCards());
    }

    [Fact]
    public void DoesDeckWithDealedCardContains51Cards_ReturnTrue()
    {
        var deckToDeal = new CardDeck();
        
        deckToDeal.DealCard();
        
        Assert.Equal(51, deckToDeal.CountCards());
    }
}