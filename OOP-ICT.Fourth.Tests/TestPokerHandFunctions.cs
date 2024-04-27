using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class TestPokerHandFunctions
{
    [Fact]
    public void CanPokerHandShowHand_InputIsHand_ReturnTrue()
    {
        var hand = new PokerHand(new PlayerHand());
        var card = new Card(CardValue.Ace, CardSuit.Clubs);
        hand.Hand.TakeCard(card);

        var hand2 = new PokerHand(new PlayerHand());
        hand2.Hand.TakeCard(card);

        Assert.Equal(hand2.Hand.ShowHand()[0], hand.Hand.ShowHand()[0]);
    }

    [Fact]
    public void CanPokerHandTakeCard_InputIsHand_ReturnTrue()
    {
        var hand = new PokerHand(new PlayerHand());
        var card = new Card(CardValue.Ace, CardSuit.Clubs);
        hand.Hand.TakeCard(card);

        var hand2 = new PokerHand(new PlayerHand());
        hand2.Hand.TakeCard(card);

        Assert.Equal(hand2.Hand.ShowHand()[0], hand.Hand.ShowHand()[0]);
    }

    [Fact]
    public void CanPokerHandShowCombination_InputIsHand_ReturnTrue()
    {
        var hand = new PokerHand(new PlayerHand());
        var card = new Card(CardValue.Ace, CardSuit.Clubs);
        hand.Hand.TakeCard(card);

        var hand2 = new PokerHand(new PlayerHand());
        hand2.Hand.TakeCard(card);

        Assert.Equal(hand2.Hand.ShowHand()[0], hand.Hand.ShowHand()[0]);
    }
}
    