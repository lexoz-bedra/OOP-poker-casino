using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class StraightFlushLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        var cardValues = hand.Cards.Select(card => card.GetValue()).ToList();
        var cardSuits = hand.Cards.Select(card => card.GetSuit()).ToList();
        if (hand.Cards.Count >= 5 && cardSuits.Distinct().Count() == 1 &&
            cardValues.Max() - cardValues.Min() == 4)
        {
            return Combination.StraightFlush;
        }

        return Next.Handle(hand);
    }
}