using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class PokerHand
{
    private Combination MaxCombination { get; set; }
    public PlayerHand Hand { get; private set; }

    public PokerHand(PlayerHand playerHand)
    {
        Hand = playerHand;
        CheckCombination();
    }

    private void CheckCombination()
    {
        var chain = new RoyalFlushLink();
        chain.AddNext(new StraightFlushLink());
        chain.AddNext(new FourOfAKindLink());
        chain.AddNext(new FullHouseLink());
        chain.AddNext(new FlushLink());
        chain.AddNext(new StraightLink());
        chain.AddNext(new ThreeOfAKindLink());
        chain.AddNext(new TwoPairsLink());
        chain.AddNext(new PairLink());
        chain.AddNext(new HighCardLink());
        MaxCombination = chain.Handle(Hand);
    }
    
    public int CompareTo(PokerHand other)
    {
        if (MaxCombination > other.MaxCombination)
        {
            return 1;
        }

        if (MaxCombination < other.MaxCombination)
        {
            return -1;
        }

        var cardValues = Hand.Cards.Select(card => card.GetValue()).ToList();
        var otherCardValues = other.Hand.Cards.Select(card => card.GetValue()).ToList();
        cardValues.Sort();
        otherCardValues.Sort();
        cardValues.Reverse();
        otherCardValues.Reverse();

        for (var i = 0; i < cardValues.Count; i++)
        {
            if (cardValues[i] > otherCardValues[i])
            {
                return 1;
            }

            if (cardValues[i] < otherCardValues[i])
            {
                return -1;
            }
        }

        return 0;
    }
}